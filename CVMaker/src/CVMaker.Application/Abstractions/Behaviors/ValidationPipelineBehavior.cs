using System.Reflection;
using CVMaker.SharedKernel;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace CVMaker.Application.Abstractions.Behaviors
{
    internal sealed class ValidationPipelineBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : class
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            // Validate the request and gather validation failures
            ValidationFailure[] validationFailures = await ValidateAsync(request);

            // If no validation failures, proceed to the next step in the pipeline
            if (validationFailures.Length == 0)
                return await next();

            // Handle validation failures for responses that are of type Result<T>
            if (typeof(TResponse).IsGenericType &&
                typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
            {
                // Get the generic type of the result
                Type resultType = typeof(TResponse).GetGenericArguments()[0];

                // Retrieve the ValidationFailure static method from Result
                MethodInfo? failureMethod = typeof(Result)
                    .GetMethod(nameof(Result.Failure))
                    ?.MakeGenericMethod(resultType);

                if (failureMethod is not null)
                {
                    // Invoke the failure method to create a validation failure response
                    return (TResponse)failureMethod.Invoke(
                        null,
                        new object[] { CreateValidationError(validationFailures) })!;
                }
            }

            // Handle validation failures for responses of type Result
            else if (typeof(TResponse) == typeof(Result))
            {
                return (TResponse)(object)Result.Failure(
                    CreateValidationError(validationFailures));
            }

            // If the response type is unsupported, throw a validation exception
            throw new ValidationException(validationFailures);
        }

        private async Task<ValidationFailure[]> ValidateAsync(TRequest request)
        {
            // If no validators, return an empty array
            if (!_validators.Any())
                return Array.Empty<ValidationFailure>();

            var context = new ValidationContext<TRequest>(request);

            // Run all validators asynchronously
            ValidationResult[] validationResults = await Task.WhenAll(
                _validators.Select(validator => validator.ValidateAsync(context)));

            // Collect all validation failures
            ValidationFailure[] validationFailures = validationResults
                .Where(result => !result.IsValid)
                .SelectMany(result => result.Errors)
                .ToArray();

            return validationFailures;
        }

        private static ValidationError CreateValidationError(ValidationFailure[] validationFailures) =>
            new(validationFailures
                .Select(f => Error.Problem(f.ErrorCode, f.ErrorMessage))
                .ToArray());
    }
}

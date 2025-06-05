using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MediatR;                        // <-- Aquí
using CbMaker.SharedKernel;           // <-- Aquí, cambia según namespace real

namespace CbMaker.Application.Abstractions.Behaviors
{
    internal sealed class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
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
            // Validar la solicitud y obtener errores de validación
            ValidationFailure[] validationFailures = await ValidateAsync(request);

            // Si no hay errores, continuar con el siguiente comportamiento en la cadena
            if (validationFailures.Length == 0)
            {
                return await next();
            }

            // Manejar errores para respuestas de tipo Result<T>
            if (typeof(TResponse).IsGenericType &&
                typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
            {
                // Obtener el tipo genérico T del Result<T>
                Type resultType = typeof(TResponse).GetGenericArguments()[0];

                // Obtener el método estático ValidationFailure de Result<T>
                MethodInfo? failureMethod = typeof(Result)
                    .MakeGenericType(resultType)
                    .GetMethod(nameof(Result<object>.ValidationFailure));

                if (failureMethod is not null)
                {
                    // Invocar el método para crear la respuesta de fallo
                    return (TResponse)failureMethod.Invoke(
                        null,
                        new object[] { CreateValidationError(validationFailures) })!;
                }
            }
            // Manejar errores para respuestas de tipo Result (no genérico)
            else if (typeof(TResponse) == typeof(Result))
            {
                return (TResponse)(object)Result.Failure(CreateValidationError(validationFailures));
            }

            // Si el tipo de respuesta no es compatible, lanzar excepción
            throw new ValidationException(validationFailures);
        }

        private async Task<ValidationFailure[]> ValidateAsync(TRequest request)
        {
            // Si no hay validadores, regresar array vacío
            if (!_validators.Any())
                return Array.Empty<ValidationFailure>();

            var context = new ValidationContext<TRequest>(request);

            // Ejecutar todos los validadores en paralelo
            ValidationResult[] validationResults = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context)));

            // Recolectar todos los errores de validación
            ValidationFailure[] failures = validationResults
                .Where(r => !r.IsValid)
                .SelectMany(r => r.Errors)
                .ToArray();

            return failures;
        }

        private static ValidationError CreateValidationError(ValidationFailure[] validationFailures) =>
            new ValidationError(validationFailures.Select(f =>
                Error.Problem(f.ErrorCode, f.ErrorMessage)).ToArray());
    }
}


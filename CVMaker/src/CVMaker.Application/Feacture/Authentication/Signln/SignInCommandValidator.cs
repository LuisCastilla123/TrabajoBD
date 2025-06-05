using FluentValidation;

namespace CVMaker.Application.Features.Authentication.SignIn

{

internal class SignInCommandValidator : AbstractValidator<SignInCommand>

{

public SignInCommandValidator()

{

            RuleFor(xx => xx.UserName)
            .NotEmpty()
            .WithMessage("User name is required.")
            .Length(3, 58)
            .WithMessage("User name must be between 3 and 58 characters.");

            RuleFor(xx => xx.Email)

            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Invalid email format.");

                RuleFor(xx => xx.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone number is required.")
                .Matches(@"^\d{4}-\d{4}$")
                .WithMessage("Phone number must be in the format XXXX-XXXX.");

            RuleFor(xx => xx.Password)
            .NotEmpty()
            .WithMessage("Password is required.")
            .MinimumLength(8)
            .WithMessage("Password must be at least 8 characters long.");

}

}

}

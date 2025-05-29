using FluentValidation;

namespace CVMaker.Application.Features.Degrees.Create
{
     internal class CreateDegreeCommandValidator : AbstractValidator<CreateDegreeCommand> { 
         public CreateDegreeCommandValidator()
        {
            RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is requerid.")
            .MaximumLength(100)
            .WithMessage("Description must not exceed 100 characters.");
        }
    }
}
   
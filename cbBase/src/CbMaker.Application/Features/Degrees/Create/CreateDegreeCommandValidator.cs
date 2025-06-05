using FluentValidation;

namespace CbMaker.Application.Features.Degrees.Create
{
    internal class CreateDegreeCommandValidator : AbstractValidator<CreateDegreeCommand>
    {
        public CreateDegreeCommandValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(100).WithMessage("Description must not exceed 100 characters.");
        }
    }
}

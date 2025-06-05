using CbMaker.Application.Abstractions.Messaging;
using FluentValidation;

namespace CbMaker.Application.Features.Skills.Create
{
    internal class CreateSkillCommandValidator : AbstractValidator<CreateSkillCommand>
    {
        public CreateSkillCommandValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(100).WithMessage("Description must not exceed 100 characters.");
        }
    }
}

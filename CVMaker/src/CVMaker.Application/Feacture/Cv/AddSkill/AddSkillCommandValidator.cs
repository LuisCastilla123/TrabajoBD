using FluentValidation;

namespace CVMaker.Application.Features.Cv.AddSkill
{
    internal class AddSkillCommandValidator : AbstractValidator<AddSkillCommand>
    {
        public AddSkillCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("User ID is required.");

            RuleFor(x => x.SkillId)
                .NotEmpty()
                .WithMessage("Skill ID is required.");
        }
    }
}

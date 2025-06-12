using FluentValidation;

namespace CVMaker.Application.Features.Cv.AddExperience
{
    internal class AddExperienceCommandValidator : AbstractValidator<AddExperienceCommand>
    {
        public AddExperienceCommandValidator()
        {
            RuleFor(x => x.EnterpriseName)
                .NotEmpty().WithMessage("Enterprise name is required.")
                .MaximumLength(100).WithMessage("Enterprise name must not exceed 100 characters.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start date is required.");

            RuleFor(x => x.EndDate)
                .GreaterThanOrEqualTo(x => x.StartDate)
                .When(x => x.EndDate.HasValue)
                .WithMessage("End date must be greater than or equal to start date.");

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage("Description must not exceed 500 characters.");

            RuleFor(x => x.JobTitleId)
                .Must(id => !id.HasValue || id.Value != Guid.Empty)
                .WithMessage("Job title ID must be a valid GUID if provided.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.")
                .Must(id => id != Guid.Empty)
                .WithMessage("User ID must be a valid GUID.");
        }
    }
}

using FluentValidation;

namespace CbMaker.Application.Features.JobTitles.Create
{
    internal class CreateJobTitleCommandValidator : AbstractValidator<CreateJobTitleCommand>
    {
        public CreateJobTitleCommandValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(108).WithMessage("Description must not exceed 108 characters.");
        }
    }
}

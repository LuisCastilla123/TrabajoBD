using CVMaker.Application.Features.JobTiles.Create;
using FluentValidation;

namespace CVMaker.Application.Features.Degrees.Create
{
     internal class CreateSkillsCommandValidator : AbstractValidator<CreateJobTItlesCommand> { 
         public CreateSkillsCommandValidator()
        {
            RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is requerid.")
            .MaximumLength(100)
            .WithMessage("Description must not exceed 100 characters.");
        }
    }
}
   
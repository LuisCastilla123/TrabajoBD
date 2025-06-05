using FluentValidation;

namespace CbMaker.Application.Features.AcademicFields.Create
{

    internal class CreateAcademicFieldCommandValidator : AbstractValidator<CreateAcademicFieldCommand>
    {
        public CreateAcademicFieldCommandValidator() {
            RuleFor(x => x.Description)
              .NotEmpty()
          .WithMessage(" Description is required. ")
          .MaximumLength(100)
          .WithMessage(" Description must not exceed 100 characters. ");
     }     
}}
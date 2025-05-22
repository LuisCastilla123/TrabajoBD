using CVMaker.Application.Abstractions.Messaging;

namespace CVMaker.Application.Features.AcademicFields.Create
{
    public record CreateAcademicFieldCommand(
        string Description
    ) : ICommand;
}   
using CVMaker.Application.Abstractions.Messaging;

namespace CVMaker.Application.Features.Degrees.Create
{
    public record CreateDegreeCommand(
        string Description
    ) : ICommand; 
}
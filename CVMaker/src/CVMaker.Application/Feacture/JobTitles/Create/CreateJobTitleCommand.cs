using CVMaker.Application.Abstractions.Messaging;

namespace CVMaker.Application.Features.JobTiles.Create
{
    public record CreateJobTItlesCommand(
        string Description
    ) : ICommand; 
}
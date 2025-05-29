using CVMaker.Application.Abstractions.Messaging;

namespace CVMaker.Application.Features.Skills.Create
{
    public record CreateSkillsCommand(
        string Description
    ) : ICommand; 
}
using CbMaker.Application.Abstractions.Messaging;
using CbMaker.SharedKernel;
using MediatR;


namespace CbMaker.Application.Features.Skills.Create
{
    public record CreateSkillCommand(string Description) : ICommand<Unit>;
}


using CbMaker.Application.Abstractions.Messaging;
using CbMaker.SharedKernel;
using MediatR;


namespace CbMaker.Application.Features.Degrees.Create
{
    public record CreateDegreeCommand(string Description) : ICommand<Unit>;
}


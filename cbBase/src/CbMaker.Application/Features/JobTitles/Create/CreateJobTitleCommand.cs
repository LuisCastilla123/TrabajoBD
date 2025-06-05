using CbMaker.Application.Abstractions.Messaging;
using CbMaker.SharedKernel;
using MediatR;


namespace CbMaker.Application.Features.JobTitles.Create
{
    public record CreateJobTitleCommand(string Description) : ICommand<Unit>;
}

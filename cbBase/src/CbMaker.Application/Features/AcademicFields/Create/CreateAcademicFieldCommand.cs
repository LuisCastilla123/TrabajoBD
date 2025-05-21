using MediatR;
using System;
using CbMaker.SharedKernel;

namespace CbMaker.Application.Features.AcademicFields.Create
{
    public record CreateAcademicFieldCommand(string Description) : IRequest<Result<Guid>>;
}

using CbMaker.SharedKernel;
using MediatR;

namespace CbMaker.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}

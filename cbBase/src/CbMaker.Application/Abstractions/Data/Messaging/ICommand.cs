using MediatR;
using CbMaker.SharedKernel;

namespace CbMaker.Application.Abstractions.Messaging
{
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}

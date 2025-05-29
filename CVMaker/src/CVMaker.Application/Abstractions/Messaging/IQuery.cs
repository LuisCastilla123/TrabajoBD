using CVMaker.SharedKernel;
using MediatR;

namespace CVMaker.Application.Abstractions.Messaging;

public interface IQuery<TResponde> : IRequest<Result<TResponde>>;
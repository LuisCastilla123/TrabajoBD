using CVMaker.SharedKernel;
using MediatR;

namespace CVMaker.Application.Abstractions.Messaging;

public interface IQueryHandler<in TQuery, TResponde> : IRequestHandler<TQuery, Result<TResponde>>
where TQuery : IQuery<TResponde>;
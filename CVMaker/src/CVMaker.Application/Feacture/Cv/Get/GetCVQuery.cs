using CVMaker.Application.Abstractions.Messaging;

namespace CVMaker.Application.Features.Cv.Get;

    public record GetCVQuery(Guid UserId) : IQuery<CVResponse>;

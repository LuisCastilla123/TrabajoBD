using CVMaker.Application.Abstractions.Messaging;

namespace CVMaker.Application.Features.Platform.Options.Get
{
    public record GetOptionsQuery() : IQuery<OptionsResponse>;
}
using MediatR;
using CbMaker.Application.Abstractions.Messaging;

namespace CbMaker.Application.Features.Platform.Options.Get
{
    public record GetOptionsQuery() : IQuery<OptionsResponse>;
}

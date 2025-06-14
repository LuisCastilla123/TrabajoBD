using CVMaker.API.Extensions;
using CVMaker.Application.Features.Degrees.Create;
using CVMaker.Application.Features.Platform.Options.Get;
using CVMaker.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CVMaker.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PlatformController : ControllerBase
    {
        private readonly ISender _mediator;

        public PlatformController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetOptions")]
        public async Task<IActionResult> getOptions()
        {
            var result = await _mediator.Send(new GetOptionsQuery());

            return result.Match<IActionResult>(
                onSuccess: () => Ok(result.Value),
                onFailure: (error) => NotFound(error.Error)
            );
        }
    }

}
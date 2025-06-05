using CbMaker.Application.Features.Platform.Options.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CbMaker.API.Controllers
{
    [ApiController] 
     [Authorize]
    [Route("[controller]")]
    public class PlatformController : ControllerBase
    {
        private readonly ISender _mediator;

        public PlatformController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetOptions")]
        public async Task<IActionResult> GetOptions()
        {
            var result = await _mediator.Send(new GetOptionsQuery());

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return NotFound(new
                {
                    ErrorCode = result.Error.Code,
                    Description = result.Error.Description  // Aquí estaba el error
                });
            }
        }
    }
}

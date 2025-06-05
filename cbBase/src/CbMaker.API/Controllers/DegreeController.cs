using CbMaker.API.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CbMaker.Application.Features.Degrees.Create;


namespace CbMaker.API.Controllers
{
    [ApiController]
     [Authorize]
    [Route("[controller]")]
    public class DegreeController : ControllerBase
    {
        private readonly ISender _mediator;

        public DegreeController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateDegreeCommand request)
        {
            var result = await _mediator.Send(request);

            return result.Match<IActionResult>(
                onSuccess: () => Ok(),
                onFailure: error => NotFound(error.Error)
            );
        }
    }
}

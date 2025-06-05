using CbMaker.API.Extensions;
using CbMaker.Application.Features.Skills.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CbMaker.API.Controllers
{
    [ApiController]
     [Authorize]
    [Route("[controller]")]
    public class SkillController : ControllerBase
    {
        private readonly ISender _mediator;

        public SkillController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateSkillCommand request)
        {
            var result = await _mediator.Send(request);

            return result.Match<IActionResult>(
                onSuccess: () => Ok(),
                onFailure: error => NotFound(error.Error)
            );
        }
    }
}

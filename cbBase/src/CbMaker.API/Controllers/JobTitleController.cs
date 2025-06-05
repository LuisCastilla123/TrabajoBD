using  CbMaker.Application.Features.JobTitles.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CbMaker.API.Controllers
{
    [ApiController]
     [Authorize]
    [Route("[controller]")]
    public class JobTitleController : ControllerBase
    {
        private readonly ISender _mediator;

        public JobTitleController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateJobTitleCommand request)
        {
            var result = await _mediator.Send(request);

            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
               return NotFound(result.Error.Description);
                }
            }
        }
    }

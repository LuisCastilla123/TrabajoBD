using CVMaker.API.Extensions;
using CVMaker.Application.Features.Degrees.Create;
using CVMaker.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CVMaker.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class JobTitlesContoller : ControllerBase
    {
        private readonly ISender _mediator;

        public JobTitlesContoller(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateDegreeCommand request)
        {
            var result = await _mediator.Send(request);

            return result.Match<IActionResult>(
                onSuccess: () => Ok(),
                onFailure: (error) => NotFound(error.Error)
            );
        }
    }

}
using CVMaker.API.Extensions;
using CVMaker.Application.Features.Cv.AddExperience;
using CVMaker.Application.Features.Cv.AddSkill;
using CVMaker.Application.Features.Cv.Get;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CVMaker.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class CVController : ControllerBase
    {
        private readonly ISender _mediator;

        public CVController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetCV")]
        public async Task<IActionResult> GetCV([FromQuery] Guid userId)
        {
            var result = await _mediator.Send(new GetCVQuery(userId));

            return result.Match<IActionResult>(
                onSuccess:  ()=> Ok(result.Value),
                onFailure: error => NotFound(error.Error)
            );
        }

        [HttpPost("AddSkill")]
        public async Task<IActionResult> AddSkill([FromBody] AddSkillCommand request)
        {
            var result = await _mediator.Send(request);

            return result.Match<IActionResult>(
                onSuccess:  ()=> Ok(),
                onFailure: error => BadRequest(error.Error)
            );
        }

        [HttpPost("AddExperience")]
        public async Task<IActionResult> AddExperience([FromBody] AddExperienceCommand request)
        {
            var result = await _mediator.Send(request);

            return result.Match<IActionResult>(
                onSuccess: ()=> Ok(),
                onFailure: error => BadRequest(error.Error)
            );
        }
    }
}

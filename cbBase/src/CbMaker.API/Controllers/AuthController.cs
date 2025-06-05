using CbMaker.Application.Features.Authentication.Signln;
using CbMaker.Application.Features.Authentication.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CbMaker.API.Controllers
{
    [ApiController]
     [Authorize]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ISender _mediator;

        public AuthController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInCommand request)
        {
            var result = await _mediator.Send(request);

            return result.Match<IActionResult>(
                onSuccess: () => Ok(),
                onFailure: error => NotFound(error.Error)
            );
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand request)
        {
            var result = await _mediator.Send(request);

            return result.Match<IActionResult>(
                onSuccess: value => Ok(value),
                onFailure: error => NotFound(error.Error)
            );
        }
    }
}

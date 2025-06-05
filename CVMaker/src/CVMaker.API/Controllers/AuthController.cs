using CVMaker.API.Extensions;
using CVMaker.Application.Features.Authentication.Login;
using CVMaker.Application.Features.Authentication.SignIn;
using CVMaker.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CVMaker.API.Controllers
{
    [ApiController]
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
                onSuccess: ( )=> Ok(),
                onFailure: error => NotFound(error.Error)
            );
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand request)
        {
            var result = await _mediator.Send(request);

            return result.Match<IActionResult>(
                onSuccess: () => Ok(result.Value),
                onFailure: error => NotFound(error.Error)
            );
        }
    }
}

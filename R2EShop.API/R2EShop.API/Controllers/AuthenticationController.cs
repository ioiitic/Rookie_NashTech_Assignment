using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using R2EShop.Application.CQRS.Authentication.Command.Register;
using R2EShop.Contracts.Authentication;
using static R2EShop.Application.CQRS.Authentication.AuthenticationDTO;

namespace R2EShop.API.Controllers
{
    [Route("authen")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.Fullname, request.EmailAddress, request.Address, request.PhoneNumber, request.PhotoUrl);

            AuthenticationResult result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            return Ok();
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SimpleLibraryApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {   
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] Service.Auth.Commands.Register.Command command) 
            => new ObjectResult(await _mediator.Send(command));

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] Service.Auth.Commands.Login.Command command)
            => new ObjectResult(await _mediator.Send(command));
    }
}
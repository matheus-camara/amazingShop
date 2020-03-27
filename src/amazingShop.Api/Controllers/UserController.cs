using System.Threading.Tasks;
using amazingShop.Api.Commands.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace amazingShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController, AllowAnonymous]
    public sealed class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator) => _mediator = mediator;

        [HttpPost("register")]
        public async Task<IActionResult> registerAsync([FromBody] RegisterUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (command.IsValid)
                return Ok(new { command.Email, command.Name });

            return BadRequest(command.Notifications);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);

            if (command.IsValid)
                return Ok(new { Token = result.Result });

            return BadRequest(command.Notifications);
        }
    }
}
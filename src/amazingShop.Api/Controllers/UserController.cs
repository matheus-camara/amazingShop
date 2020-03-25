using System.Threading.Tasks;
using amazingShop.Api.Commands.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace amazingShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public sealed class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> registerAsync([FromBody] RegisterUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (command.IsValid)
                return Ok(command);

            return BadRequest(command.Notifications);
        }
    }
}
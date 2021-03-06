using System.Threading.Tasks;
using amazingShop.Api.Commands.Products;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace amazingShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public sealed class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        [HttpGet("{skip:min(0)}/{take:min(1)}"), AllowAnonymous]
        public async Task<IActionResult> GetAsync([FromRoute] GetProductsCommand command, [FromQuery] GetProductsFilter filter)
        {
            command.Filter = filter;

            var result = await _mediator.Send(command);

            if (result.IsValid)
                return Ok(new { result.Result });

            return NoContent();
        }

        [HttpGet("{id:min(1)}"), AllowAnonymous]
        public async Task<IActionResult> GetAsync([FromRoute] GetProductCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsValid)
                return Ok(new { result.Result });

            return NotFound(command.Notifications);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddProductCommand command)
        {
            command.User = User.GetIdentifier();
            var result = await _mediator.Send(command);

            if (result.IsValid)
                return Created(nameof(GetAsync), new { result.Result });
            else
                return BadRequest(command.Notifications);
        }

        [HttpPut("{id:min(1)}")]
        public async Task<IActionResult> PutAsync([FromRoute] long id, [FromBody] EditProductCommand command)
        {
            command.User = User.GetIdentifier();
            var result = await _mediator.Send(command);

            if (result.IsValid)
                return Accepted();
            else
                return BadRequest(command.Notifications);
        }

        [HttpDelete("{id:min(1)}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteProductCommand command)
        {
            command.User = User.GetIdentifier();
            var result = await _mediator.Send(command);

            if (result.IsValid)
                return Ok();
            else
                return BadRequest(command.Notifications);
        }

        public ProductController(IMediator mediator)
            => (_mediator) = (mediator);
    }
}
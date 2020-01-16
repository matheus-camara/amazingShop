using amazingShop.Domain.Core.Commands;
using amazingShop.Domain.Core.Commands.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace amazingShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController, AllowAnonymous]
    public sealed class ProductController : ControllerBase
    {
        private readonly ICommandHandler<AddProductCommand> _addProductHandler;

        public ProductController(ICommandHandler<AddProductCommand> addProductHandler)
        {
            _addProductHandler = addProductHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddProductCommand command)
        {
            var result = await _addProductHandler.ExecuteAsync(command);

            if (result.IsValid)
                return CreatedAtAction("[action]", command);
            else
                return BadRequest(command.Notifications);
        }
    }
}
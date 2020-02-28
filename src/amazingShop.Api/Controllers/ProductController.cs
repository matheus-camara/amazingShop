using System.Threading.Tasks;
using amazingShop.Domain.Core.Commands;
using amazingShop.Domain.Core.Commands.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace amazingShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController, AllowAnonymous]
    public sealed class ProductController : ControllerBase
    {
        private readonly ICommandHandler<AddProductCommand> _addProductHandler;

        private readonly ICommandHandler<GetProductCommand> _getProductHandler;

        private readonly ICommandHandler<GetProductsCommand> _getProductsHandler;

        public ProductController(ICommandHandler<AddProductCommand> addProductHandler, ICommandHandler<GetProductCommand> getProductHandler, ICommandHandler<GetProductsCommand> getProductsHandler)
        {
            _addProductHandler = addProductHandler;
            _getProductHandler = getProductHandler;
            _getProductsHandler = getProductsHandler;
        }

        [HttpGet("{skip:min(0)}/{take:min(1)}")]
        public async Task<IActionResult> GetAsync([FromRoute] GetProductsCommand command)
        {
            var result = await _getProductsHandler.ExecuteAsync(command);

            if (result.IsValid)
                return Ok(result);

            return NoContent();
        }

        [HttpGet("{id:min(1)}")]
        public async Task<IActionResult> GetAsync([FromRoute] GetProductCommand command)
        {
            var result = await _getProductHandler.ExecuteAsync(command);

            if (result.IsValid)
                return Ok(result.Result);

            return NotFound(command);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddProductCommand command)
        {
            var result = await _addProductHandler.ExecuteAsync(command);

            if (result.IsValid)
                return Created(nameof(GetAsync), new { result.Name, result.Description, result.ImageUrl, result.Price, result.Timestamp });
            else
                return BadRequest(command.Notifications);
        }
    }
}
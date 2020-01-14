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
        [HttpPost]
        public async Task Post([FromBody] AddProductCommand command)
        { 
        }
    }
}
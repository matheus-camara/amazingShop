using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace amazingShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController, AllowAnonymous]
    public sealed class ProductController : ControllerBase
    {
    }
}
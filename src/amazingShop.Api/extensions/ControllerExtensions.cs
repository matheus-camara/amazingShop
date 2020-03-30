using System.Security.Claims;

namespace amazingShop.Api.Controllers
{
    public static class ControllerExtensions
    {
        public static long GetIdentifier(this ClaimsPrincipal user)
            => long.Parse(user.FindFirst(x => x.Type == ClaimTypes.PrimarySid).Value);
    }
}
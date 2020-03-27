using System.Threading.Tasks;
using amazingShop.Api.Commands.Users;
using amazingShop.Domain.Entities;

namespace amazingShop.Api.Services.Users
{
    public interface IAuthenticationService
    {
        User Register(string name, string email, string password);

        string? Login(User user, string password);
    }
}
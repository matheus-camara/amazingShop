using amazingShop.Domain.Entities;
using amazingShop.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace amazingShop.Infra.Repositories.Users
{
    public sealed class UserRepository : Repository<ShopContext, User>, IRepository<User>
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}
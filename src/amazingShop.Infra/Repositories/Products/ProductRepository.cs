using System.Threading.Tasks;
using amazingShop.Domain.Entities;
using amazingShop.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace amazingShop.Infra.Repositories.Products
{
    public sealed class ProductRepository : Repository<ShopContext, Product>, IRepository<Product>
    {
        public ProductRepository(ShopContext context) : base(context)
        {
        }
    }
}

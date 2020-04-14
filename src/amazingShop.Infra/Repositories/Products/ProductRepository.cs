using System.Linq;
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

        public override async Task<Product?> FindAsync(long primaryKey) => await Context.Set<Product>().Include(x => x.AddedBy).FirstOrDefaultAsync(x => x.Id == primaryKey);
    }
}

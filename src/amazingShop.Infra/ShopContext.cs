using amazingShop.Domain.Entities;
using amazingShop.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace amazingShop.Infra
{
    public sealed class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions optionsBuilder) : base(optionsBuilder)
        {
            Database.Migrate();
        }

        public DbSet<Product> Products { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();
            modelBuilder.ApplyConfiguration(new ProductMapping());
        }
    }
}
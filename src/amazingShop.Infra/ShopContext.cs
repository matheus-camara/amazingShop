using amazingShop.Domain.Entities;
using amazingShop.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace amazingShop.Infra
{
    public sealed class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> optionsBuilder) : base(optionsBuilder)
        {
        }

        public DbSet<Product> Products { get; } = default!;

        public DbSet<User> Users { get; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new EventMapping());
        }
    }
}
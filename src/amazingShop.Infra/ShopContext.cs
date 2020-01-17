using amazingShop.Domain.Entities;
using amazingShop.Domain.Core.Events;
using amazingShop.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace amazingShop.Infra
{
    public sealed class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> optionsBuilder) : base(optionsBuilder)
        {
            Database.Migrate();
        }

        public DbSet<Product> Products { get; }

        public DbSet<Event> Events { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new EventMapping());
        }
    }
}
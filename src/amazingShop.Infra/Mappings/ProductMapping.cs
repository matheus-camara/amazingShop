using amazingShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace amazingShop.Infra.Mappings
{
    public sealed class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(p => p.Id).IsClustered();

            builder.Ignore(p => p.Notifications);

            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();

            builder.Property(p => p.Name).HasMaxLength(70).IsRequired();

            builder.Property(p => p.Price).IsRequired();

            builder.Property(p => p.ImageUrl).HasMaxLength(512).IsRequired();

            builder.HasData(
                Enumerable.Range(1, 20)
                .Select(x => new Product(
                    id: x,
                    name: "camiseta",
                    description: "camiseta",
                    price: 18.28,
                    imageUrl: "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg")));
        }
    }
}
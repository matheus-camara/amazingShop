using amazingShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace amazingShop.Infra.Mappings
{
    public sealed class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id).IsClustered();

            builder.Ignore(p => p.Notifications);

            builder.Property(p => p.Name).HasMaxLength(60);

            builder.Property(p => p.Price);

            builder.Property(p => p.ImageUrl).HasMaxLength(100);
        }
    }
}

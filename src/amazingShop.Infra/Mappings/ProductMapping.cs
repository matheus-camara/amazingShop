using System;
using amazingShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace amazingShop.Infra.Mappings
{
    public sealed class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id).IsClustered();

            builder.Ignore(p => p.Notifications);

            builder.Property(p => p.Name).HasMaxLength(60).IsRequired();

            builder.Property(p => p.Price).IsRequired();

            builder.Property(p => p.ImageUrl).HasMaxLength(200).IsRequired();
        }
    }
}
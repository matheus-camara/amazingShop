using amazingShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace amazingShop.Infra.Mappings
{
    public sealed class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(p => p.Id).IsClustered();

            builder.HasAlternateKey(p => p.Email);

            builder.Ignore(p => p.Notifications);

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.Property(p => p.Email).HasMaxLength(150).IsRequired();

            builder.Property(p => p.Password).IsRequired();

            builder.Property(p => p.Salt).IsRequired();

            builder.HasIndex(p => p.Email);
        }
    }
}
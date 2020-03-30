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

            builder.HasAlternateKey(p => p.Name);

            builder.Ignore(p => p.Notifications);

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.Property(p => p.Email).HasMaxLength(150).IsRequired();

            builder.Property(p => p.Password).IsRequired();

            builder.Property(p => p.Salt).IsRequired();

            builder.HasIndex(p => p.Name);

            builder.HasData(
                new User(
                    id: 1,
                    email: "admin@admin.com",
                    name: "admin",
                    password: System.Text.Encoding.UTF8.GetBytes("0x9E3014F8352FCEAB3265158AEB5E413675976D3813DAC2A209650A797EE75ACA17DB29DCAC87F36602E66312ED2ADC24E596990E03C6F548A75626491C504A910"),
                    salt: System.Text.Encoding.UTF8.GetBytes("0xC7F14ABB7A05789C6BD6A63D027AB10FDAA51D9DF4A8CCFBEA9971CD040ADF05E57EE8B9A09D8145EEC0C2CE26C905586CB694D6DBE387D9E35A22AE735C9E8362F33F887B4E65E2F4715FA1EFBAD11C66719EEE22C7A7B575CD37F071A5B6B5C8C27D47E74012672E76B9306AD5AC7ABE650770AE93F48EA457CBD56ADD2E6C")
                ));
        }
    }
}
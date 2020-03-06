using amazingShop.Domain.Core.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace amazingShop.Infra.Mappings
{
    public class EventMapping : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events");

            builder.HasKey(P => P.Id).IsClustered();

            builder.Property(p => p.Type).IsRequired();

            builder.Property(p => p.Timestamp).IsRequired();
        }
    }
}
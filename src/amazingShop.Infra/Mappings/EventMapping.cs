using amazingShop.Domain.Core.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace amazingShop.Infra.Mappings
{
    public class EventMapping : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("event");

            builder.Property(e => e.Timestamp);

            builder.Ignore(e => e.Notifications);

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.HasKey(e => e.Id).IsClustered();

            builder.Property(e => e.Type).HasMaxLength(40);

            builder.Property(e => e.Data);
        }
    }
}

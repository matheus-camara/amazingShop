using amazingShop.Domain.Core.Events;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Diagnostics.CodeAnalysis;

namespace amazingShop.Infra.Mappings
{
    internal class DataGenerator : ValueGenerator
    {
        public override bool GeneratesTemporaryValues => false;

        protected override object NextValue([NotNull] EntityEntry entry)
        {
            return Jil.JSON.Serialize(entry);
        }
    }
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

            builder.Property(e => e.Data).ValueGeneratedOnAdd().HasValueGenerator<DataGenerator>();
        }
    }
}

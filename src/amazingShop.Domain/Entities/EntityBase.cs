using System;
using amazingShop.Domain.Core.Notifications;

namespace amazingShop.Domain.Entities
{
    public abstract class EntityBase : Notifiable
    {
        protected EntityBase() { }
        public EntityBase(long id) => Id = id;

        public long Id { get; private set; } = default!;

        public override bool Equals(object? obj) => obj is EntityBase @base && Id == @base.Id;

        public override int GetHashCode() => HashCode.Combine(Id);

        public static bool operator ==(EntityBase? one, object? other) => other is EntityBase @base && one != null && one.Id == @base.Id;

        public static bool operator !=(EntityBase? one, object? other) => other is EntityBase @base && one != null && one.Id != @base.Id;
    }
}
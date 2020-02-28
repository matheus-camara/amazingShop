using System;
using amazingShop.Domain.Core.Notifications;

namespace amazingShop.Domain.Entities
{
    public abstract class EntityBase : Notifiable, IEquatable<object>
    {
        protected EntityBase() { }
        protected EntityBase(long id)
            => Id = id;

        public long Id { get; private set; }

        public override bool Equals(object obj)
            => obj is EntityBase @base 
                && Id == @base?.Id;

        public override int GetHashCode()
            => HashCode.Combine(Id);

        static public bool operator ==(EntityBase one, EntityBase other) => one.Id == other?.Id;

        static public bool operator !=(EntityBase one, EntityBase other) => !(one.Id == other?.Id);
    }
}
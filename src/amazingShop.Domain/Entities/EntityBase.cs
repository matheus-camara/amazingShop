using System;
using amazingShop.Domain.Core.Notifications;

namespace amazingShop.Domain.Entities
{
    public abstract class EntityBase : Notifiable
    {
        protected EntityBase() { }
        protected EntityBase(long id)
            => Id = id;

        public long Id { get; private set; } = default!;
    }
}
using amazingShop.Domain.Core.Notifications;

namespace amazingShop.Domain.Entities
{
    public abstract class EntityBase : Notifiable
    {
        public long Id { get; private set; }
    }
}
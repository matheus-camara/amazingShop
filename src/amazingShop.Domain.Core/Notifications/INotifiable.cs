using System.Collections.Generic;

namespace amazingShop.Domain.Core.Notifications
{
    public interface INotifiable
    {
        IEnumerable<Notification> Notifications { get; }

        void AddNotification(Notification notification);

        void AddNotification(IEnumerable<Notification> notifications);

        bool HasNotification { get; }
    }
}
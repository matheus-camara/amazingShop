using System.Collections.Generic;

namespace amazingShop.Domain.Core.Notifications
{
    public interface INotifiable
    {
        void AddNotification(Notification notification);

        void AddNotification(IEnumerable<Notification> notifications);

        bool HasNotification { get; }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace amazingShop.Domain.Core.Notifications
{
    public abstract class Notifiable : INotifiable
    {
        private IEnumerable<Notification>? _notifications;

        public IEnumerable<Notification> Notifications { get => _notifications ??= new List<Notification>(); }

        public void AddNotification(Notification notification)
        {
            if (!Notifications.Contains(notification))
                _notifications = _notifications?.Append(notification);
        }

        public void AddNotification(IEnumerable<Notification> notifications)
        {
            foreach (var notification in notifications)
            {
                AddNotification(notification);
            }
        }

        public bool HasNotification => _notifications?.Any() ?? false;

        public virtual bool IsValid => !HasNotification;
    }
}
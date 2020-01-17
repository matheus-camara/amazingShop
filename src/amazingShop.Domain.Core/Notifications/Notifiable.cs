using System.Collections.Generic;

namespace amazingShop.Domain.Core.Notifications
{
    public abstract class Notifiable : INotifiable
    {
        private List<Notification> _notifications;

        public List<Notification> Notifications
        {
            get
            {
                if (_notifications is null)
                    _notifications = new List<Notification>();

                return _notifications;
            }

            private set
            {
                _notifications = value;
            }
        }

        public void AddNotification(Notification notification)
        {
            if (!Notifications.Contains(notification))
                Notifications.Add(notification);
        }

        public void AddNotification(IEnumerable<Notification> notifications)
        {
            foreach(var notification in notifications)
            {
                AddNotification(notification);
            }

            notifications = null;
        }

        public bool HasNotification => Notifications.Count != default;

        public bool IsValid => !HasNotification;
    }
}
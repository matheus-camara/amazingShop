using System;
using amazingShop.Domain.Core.Notifications;

namespace amazingShop.Domain.Core.Validators
{
    public abstract class Rule<T> : IRule<T> where T : class
    {
        private Func<Notification>[] _notifications;

        protected Func<Notification>[] Notifications
        {
            get => _notifications ??= Array.Empty<Func<Notification>>();
        }

        public Rule(params Func<Notification>[] notificationsFactory)
        {
            _notifications = notificationsFactory;
        }

        public abstract void ApplyTo(T target);
    }
}
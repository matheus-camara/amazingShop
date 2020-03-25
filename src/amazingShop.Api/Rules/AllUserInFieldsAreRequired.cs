using System;
using System.Linq;
using amazingShop.Api.Commands.Users;
using amazingShop.Domain.Core.Notifications;
using amazingShop.Domain.Core.Validators;

namespace amazingShop.Api.Rules
{
    public class AllUserInFieldsAreRequired : Rule<RegisterUserCommand>
    {
        public AllUserInFieldsAreRequired(params Func<Notification>[] notificationsFactory) : base(notificationsFactory)
        {
        }

        public override void ApplyTo(RegisterUserCommand target)
        {
            if (string.IsNullOrEmpty(target.Name) || string.IsNullOrEmpty(target.Email) || string.IsNullOrEmpty(target.Password))
                target.AddNotification(Notifications.Select(x => x.Invoke()));

        }
    }
}
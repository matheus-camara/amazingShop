using System;
using System.Linq;
using amazingShop.Api.Commands.Users;
using amazingShop.Domain.Core.Notifications;
using amazingShop.Domain.Core.Validators;

namespace amazingShop.Api.Rules
{
    public sealed class UsernameAndPasswordRequiredRule : Rule<LoginCommand>
    {
        public UsernameAndPasswordRequiredRule(params Func<Notification>[] notifications) : base(notifications)
        {
        }

        public override void ApplyTo(LoginCommand target)
        {
            if (string.IsNullOrEmpty(target.Name) || string.IsNullOrEmpty(target.Password))
                target.AddNotification(Notifications.Select(x => x.Invoke()));
        }
    }
}
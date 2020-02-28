using amazingShop.Domain.Core.Notifications;
using Microsoft.Extensions.Localization;

namespace amazingShop.Api.Localization
{
    public class NotificationFactory : INotificationFactory
    {
        private readonly IStringLocalizer _localizer;

        public NotificationFactory(IStringLocalizer localizer)
            => _localizer = localizer;

        public Notification Get(string code) => new Notification(code, _localizer.GetString(code));
    }
}
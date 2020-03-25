using System;
using System.Linq;
using amazingShop.Domain.Core.Notifications;
using amazingShop.Domain.Core.Validators;
using amazingShop.Domain.Entities;

namespace amazingShop.Domain.Rules.Products
{
    public sealed class AllProductFieldsAreRequiredRule : Rule<Product>
    {
        public AllProductFieldsAreRequiredRule(params Func<Notification>[] notificationsFactory) : base(notificationsFactory)
        {
        }

        public override void ApplyTo(Product target)
        {
            if (string.IsNullOrEmpty(target.Name) || string.IsNullOrEmpty(target.Description) || string.IsNullOrEmpty(target.ImageUrl) || target.Price == default(double))
                target.AddNotification(Notifications.Select(x => x.Invoke()));
        }
    }
}
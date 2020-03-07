using amazingShop.Domain.Core.Notifications;
using amazingShop.Domain.Core.Validators;
using amazingShop.Domain.Entities;

namespace amazingShop.Domain.Rules.Products
{
    public sealed class AllProductFieldsAreRequiredRule : Rule<Product>
    {
        public AllProductFieldsAreRequiredRule(params Notification[] notifications) : base(notifications)
        {

        }

        public override bool ApplyTo(Product target)
        {
            if (string.IsNullOrEmpty(target.Name) || string.IsNullOrEmpty(target.Description) || string.IsNullOrEmpty(target.ImageUrl) || target.Price == default(double))
                target.AddNotification(Notifications);

            return target.IsValid;
        }
    }
}
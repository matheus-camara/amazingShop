using amazingShop.Domain.Entities;
using amazingShop.Domain.Validators;

namespace amazingShop.Domain.Rules.Products
{
    public sealed class AllProductFieldsAreRequiredRule : Rule<Product>
    {
        public override bool ApplyTo(Product target)
        {
            if (string.IsNullOrEmpty(target.Name) || string.IsNullOrEmpty(target.ImageUrl) || target.Price == default)
                target.AddNotification(new Domain.Core.Notifications.Notification("All Fields are required"));

            return target.IsValid;
        }
    }
}

using System.Linq;
using amazingShop.Domain.Core.Validators;
using amazingShop.Domain.Entities;

namespace amazingShop.Domain.Rules.Users
{
    public class AllUserFieldsAreRequiredRule : Rule<User>
    {
        public override void ApplyTo(User target)
        {
            if (string.IsNullOrEmpty(target.Name) || string.IsNullOrEmpty(target.Email) || ((!target.Password?.Any()) ?? true))
                target.AddNotification(Notifications.Select(x => x.Invoke()));
        }
    }
}
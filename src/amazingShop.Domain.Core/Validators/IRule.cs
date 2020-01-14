using amazingShop.Domain.Core.Notifications;

namespace amazingShop.Domain.Core.Validators
{
    public interface IRule<T> where T : INotifiable
    {
        bool ApplyTo(T target);
    }
}

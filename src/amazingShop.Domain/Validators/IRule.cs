using amazingShop.Domain.Entities;

namespace amazingShop.Domain.Validators
{
    public interface IRule<T> where T : EntityBase
    {
        bool ApplyTo(T target);
    }
}

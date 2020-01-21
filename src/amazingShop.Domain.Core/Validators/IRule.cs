namespace amazingShop.Domain.Core.Validators
{
    public interface IRule<T> where T : class
    {
        bool ApplyTo(T target);
    }
}
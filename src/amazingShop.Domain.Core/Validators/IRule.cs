namespace amazingShop.Domain.Core.Validators
{
    public interface IRule<T> where T : class
    {
        void ApplyTo(T target);
    }
}
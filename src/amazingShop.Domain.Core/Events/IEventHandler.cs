namespace amazingShop.Domain.Core.Events
{
    public interface IEventHandler<T> where T : Event
    {
        void Handle(object sender, T e);
    }
}

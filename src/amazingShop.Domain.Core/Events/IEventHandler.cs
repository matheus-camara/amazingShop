namespace amazingShop.Domain.Core.Events
{
    public interface IEventHandler<T> where T : Event
    {
        void Handle(T @event);
    }
}

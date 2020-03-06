using MediatR;

namespace amazingShop.Domain.Core.Events
{
    public interface IEventHandler<T> where T : INotification, INotificationHandler<T>
    {

    }
}
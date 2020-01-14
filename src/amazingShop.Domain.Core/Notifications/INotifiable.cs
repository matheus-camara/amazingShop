namespace amazingShop.Domain.Core.Notifications
{
    public interface INotifiable
    {
        void AddNotification(Notification notification);

        bool HasNotification { get; }
    }
}
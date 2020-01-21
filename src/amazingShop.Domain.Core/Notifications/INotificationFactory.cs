namespace amazingShop.Domain.Core.Notifications
{
  public interface INotificationFactory
  {
    Notification Get(string code);
  }
}
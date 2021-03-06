namespace amazingShop.Domain.Core.Notifications
{
    public struct Notification
    {
        public string Id { get; }

        public string Value { get; }

        public Notification(string code, string value)
        {
            Id = code;
            Value = value;
        }
    }
}
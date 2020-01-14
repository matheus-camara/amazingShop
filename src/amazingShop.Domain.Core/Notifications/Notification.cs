using System;

namespace amazingShop.Domain.Core.Notifications
{
    public class Notification
    {
        public readonly Guid Id;

        public readonly string Value;

        public Notification(Guid id, string value)
        {
            Id = id;
            Value = value;
        }

        public Notification(string value) : this(Guid.NewGuid(), value) { }
 
    }
}
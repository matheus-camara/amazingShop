using System;

namespace amazingShop.Domain.Core.Notifications
{
    public class Notification
    {
        public Guid Id { get; }

        public string Value { get; }

        public Notification(Guid id, string value)
        {
            Id = id;
            Value = value;
        }

        public Notification(string value) : this(Guid.NewGuid(), value) { }
 
    }
}
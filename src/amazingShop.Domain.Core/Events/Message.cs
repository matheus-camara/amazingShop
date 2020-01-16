using amazingShop.Domain.Core.Notifications;
using System;

namespace amazingShop.Domain.Core.Events
{
    public abstract class Message : Notifiable
    {
        public Guid Id { get; }

        public string Type { get; }

        protected Message()
        {
            Id = Guid.NewGuid();
        }

        protected Message(string type) : this()
        { 
            Type = type;
        }
    }
}
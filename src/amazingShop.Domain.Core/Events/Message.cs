using System;
using amazingShop.Domain.Core.Notifications;

namespace amazingShop.Domain.Core.Events
{
    public abstract class Message : Notifiable
    {
        public string Type { get; }

        protected Message(string type)
        {
            Type = type;
        }
    }
}
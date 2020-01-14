using System;

namespace amazingShop.Domain.Core.Events
{
    public abstract class Message
    {
        public Guid Id { get; private set; }

        protected static readonly string Type = typeof(Message).Name;

        protected Message()
        {
            Id = Guid.NewGuid();
        }
    }
}
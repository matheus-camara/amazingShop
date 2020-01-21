using System;

namespace amazingShop.Domain.Core.Events
{
    public abstract class Event : Message, IEvent
    {
        private const string _type = "Event";

        public DateTime Timestamp { get; }

        private Guid Id { get; }

        protected Event(string type) : base(type)
        {
            Timestamp = DateTime.Now;
            Id = Guid.NewGuid();
        }

        public abstract void Dispatch();
    }
}
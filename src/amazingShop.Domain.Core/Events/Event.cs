using System;

namespace amazingShop.Domain.Core.Events
{
    public abstract class Event : Message, IEvent, IEquatable<object>
    {
        private const string _type = "Event";

        public DateTime Timestamp { get; }

        private Guid Id { get; }

        protected Event(string type) : base(type)
        {
            Timestamp = DateTime.Now;
            Id = Guid.NewGuid();
        }

        static public bool operator ==(Event one, Event other) => one?.Id == other?.Id;

        static public bool operator !=(Event one, Event other) => !(one?.Id == other?.Id);
        public abstract void Dispatch();

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   Timestamp == @event.Timestamp &&
                   Id.Equals(@event.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Timestamp, Id);
        }
    }
}
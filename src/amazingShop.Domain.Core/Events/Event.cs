using System;

namespace amazingShop.Domain.Core.Events
{
    public abstract class Event : Message
    {
        public readonly DateTime Timestamp;

        public EventParam Params { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
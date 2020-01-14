using System;

namespace amazingShop.Domain.Core.Events
{
    public abstract class Event : Message
    {
        public readonly DateTime Timestamp;

        protected new static readonly string Type = typeof(Event).Name;
        protected EventParam Params { get; set; }

        protected Event(): base()
        {            
            Timestamp = DateTime.Now;
        }
    }
}
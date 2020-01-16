using System;

namespace amazingShop.Domain.Core.Events
{
    public abstract class Event : Message
    {
        private const string _type = "Event";

        public DateTime Timestamp { get; }

        public string? Data = null;

        protected Event(): base(_type)
        {            
            Timestamp = DateTime.Now;
        }

        protected Event(string type) : base(type)
        {
            Timestamp = DateTime.Now;
        }
    }
}
using System;
using Jil;

namespace amazingShop.Domain.Core.Events
{
    public class Event : Message
    {
        private const string _type = "Event";

        public DateTime Timestamp { get; }

        public string Data { get; private set; }

        protected Event(): base(_type)
        {            
            Timestamp = DateTime.Now;
        }

        protected Event(string type) : base(type)
        {
            Timestamp = DateTime.Now;
        }

        public void GenerateLogData() => Data = Jil.JSON.Serialize(this);
    }
}
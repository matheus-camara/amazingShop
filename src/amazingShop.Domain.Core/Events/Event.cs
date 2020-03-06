using System;
using MediatR;
using System.Text.Json;

namespace amazingShop.Domain.Core.Events
{
    public abstract class Event : INotification
    {
        public DateTime Timestamp { get; }

        public long Id { get; }

        private string _data;
        public string Data
        {
            get
            {
                if (string.IsNullOrEmpty(_data))
                    _data = JsonSerializer.Serialize(this);

                return _data;
            }
        }

        public virtual string Type => "Event";

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
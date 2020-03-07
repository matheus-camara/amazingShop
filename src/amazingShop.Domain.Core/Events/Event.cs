using System;
using MediatR;

namespace amazingShop.Domain.Core.Events
{
    public class Event : INotification
    {
        public DateTime Timestamp { get; }

        public long Id { get; }

        public string Type { get; private set; }

        protected Event()
        {
            Type = this.GetType().Name;
            Timestamp = DateTime.Now;
        }
    }
}
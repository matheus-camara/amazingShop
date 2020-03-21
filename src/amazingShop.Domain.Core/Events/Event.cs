using System;
using MediatR;
using System.Text.Json;
using System.Threading.Tasks;

namespace amazingShop.Domain.Core.Events
{
    public class Event : INotification
    {
        public long Id { get; } = default!;

        public DateTime Timestamp { get; private set; } = default!;

        public string Type { get; private set; } = default!;

        public string Data { get; private set; } = default!;

        protected void SaveData()
        {
            Timestamp = DateTime.Now;
            Type = this.GetType().Name;
            Data = JsonSerializer.Serialize(this);
        }
    }
}
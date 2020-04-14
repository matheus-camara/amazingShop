using System;
using System.Text.Json;
using MediatR;

namespace amazingShop.Domain.Core.Events
{
    public class Event : INotification
    {
        public long Id { get; } = default!;

        public DateTime Timestamp { get; private set; } = DateTime.Now;

        public string Type { get; private set; } = default!;

        public string Data { get; protected set; } = default!;

        public void SetData()
        {
            Type = this.GetType().Name;
            Data = JsonSerializer.Serialize(GetData(), new JsonSerializerOptions
            {
                MaxDepth = 0,
                IgnoreNullValues = true,
            });
        }

        protected virtual object GetData() => new { };
    }
}
using System;
using MediatR;

namespace amazingShop.Domain.Core.Events
{
    public class Event : INotification
    {
        public long Id { get; } = default!;

        public DateTime Timestamp { get; private set; } = default!;

        public string Type { get; private set; } = default!;

        public string Data { get; protected set; } = default!;
    }
}
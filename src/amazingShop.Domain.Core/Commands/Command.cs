using System;
using amazingShop.Domain.Core.Events;
using amazingShop.Domain.Core.Notifications;
using MediatR;

namespace amazingShop.Domain.Core.Commands
{
    public abstract class Command : Notifiable
    {
        public DateTime Timestamp { get; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
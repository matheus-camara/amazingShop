using amazingShop.Domain.Core.Events;;
using System;

namespace amazingShop.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public new static readonly string Type = typeof(Command).Name;

        public readonly DateTime Timestamp;

        protected Command() : base() 
        {
            Timestamp = DateTime.Now;
        }
    }
}

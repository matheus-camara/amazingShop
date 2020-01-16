﻿using amazingShop.Domain.Core.Events;
using System;

namespace amazingShop.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        private const string _type = "command";

        public DateTime Timestamp { get; }

        protected Command() : base(_type) 
        {
            Timestamp = DateTime.Now;
        }
    }
}
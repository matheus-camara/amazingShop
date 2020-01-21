using System;
using amazingShop.Domain.Core.Events;
using amazingShop.Domain.Repositories;

namespace amazingShop.Domain.Events.Products
{
    public sealed class ProductAddedEventHandler : IEventHandler<ProductAddedEvent>
    {
        public void Handle(object _, ProductAddedEvent e)
        {
            Console.WriteLine($"Event: {e.Type} occured at {e.Timestamp}");
        }
    }
}
using System;
using amazingShop.Domain.Core.Events;
using amazingShop.Domain.Events.Products;

namespace amazingShop.Api.EventHandlers.Products
{
    public sealed class ProductAddedEventHandler : IEventHandler<ProductAddedEvent>
    {
        public void Handle(object _, ProductAddedEvent e)
        {
            Console.WriteLine($"Event: {e.Type} occured at {e.Timestamp}");
        }
    }
}
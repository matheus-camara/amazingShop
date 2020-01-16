using amazingShop.Domain.Core.Events;
using System;

namespace amazingShop.Domain.Events.Products
{
    public sealed class ProductAddedEventHandler : IEventHandler<ProductAddedEvent>
    {
        public void Handle(object _, ProductAddedEvent e)
        {
        }
    }
}

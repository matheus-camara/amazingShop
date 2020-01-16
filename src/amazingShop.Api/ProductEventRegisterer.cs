using amazingShop.Domain.Core.Events;
using amazingShop.Domain.Events.Products;
using System;

namespace amazingShop.Api
{
    public class ProductEventRegisterer : IDisposable
    {
        private IEventHandler<ProductAddedEvent> ProductAddedHandler;

        public ProductEventRegisterer(IEventHandler<ProductAddedEvent> productAddedHandler)
        {
            ProductAddedHandler = productAddedHandler;
        }

        public void Register()
        {
            ProductAddedEvent.Dispatcher += ProductAddedHandler.Handle;
        }

        public void Dispose()
        {
            ProductAddedEvent.Dispatcher -= ProductAddedHandler.Handle;
        }
    }
}

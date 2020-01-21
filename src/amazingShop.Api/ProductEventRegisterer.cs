using System;
using amazingShop.Domain.Core.Events;
using amazingShop.Domain.Events.Products;

namespace amazingShop.Api
{
    public sealed class ProductEventRegisterer : IDisposable
    {
        private IEventHandler<ProductAddedEvent> ProductAddedHandler;

        public ProductEventRegisterer(IEventHandler<ProductAddedEvent> productAddedHandler)
        {
            ProductAddedHandler = productAddedHandler;
        }

        public void Register()
        {
            ProductAddedEvent.Handler += ProductAddedHandler.Handle;
        }

        public void Dispose()
        {
            ProductAddedEvent.Handler -= ProductAddedHandler.Handle;
        }
    }
}
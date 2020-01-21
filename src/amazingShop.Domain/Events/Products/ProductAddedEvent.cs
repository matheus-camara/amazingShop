using amazingShop.Domain.Core.Events;
using amazingShop.Domain.Entities;
using System;

namespace amazingShop.Domain.Events.Products
{
    public sealed class ProductAddedEvent : Event
    {
        private const string _type = "ProductAdded"; 

        public static event EventHandler<ProductAddedEvent> Handler;

        public Product Added;

        public ProductAddedEvent(Product added) : base(_type)
        {
            Added = added;
        }
        public override void Dispatch() => Handler.Invoke(string.Empty, this);   
    }
}

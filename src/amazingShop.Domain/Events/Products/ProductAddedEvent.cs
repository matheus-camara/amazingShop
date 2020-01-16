using amazingShop.Domain.Core.Events;
using amazingShop.Domain.Entities;
using System;

namespace amazingShop.Domain.Events.Products
{
    public sealed class ProductAddedEvent : Event
    {
        private const string _type = "ProductAdded"; 

        public static event EventHandler<ProductAddedEvent> Dispatcher;

        public Product Added;

        public static void Dispatch(Product added) => new ProductAddedEvent(added);

        private ProductAddedEvent(Product added) : base(_type)
        {
            Added = added;
            Dispatcher.Invoke("None", this);
        } 
    }
}

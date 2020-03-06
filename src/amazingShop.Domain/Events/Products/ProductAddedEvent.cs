using amazingShop.Domain.Core.Events;
using amazingShop.Domain.Entities;
using MediatR;
using System;

namespace amazingShop.Domain.Events.Products
{
    public sealed class ProductAddedEvent : Event, INotification
    {
        public override string Type => "ProductAdded";

        public Product Added;

        public ProductAddedEvent(Product added)
        {
            Added = added;
        }
    }
}

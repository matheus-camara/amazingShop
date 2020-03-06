using amazingShop.Domain.Core.Events;
using amazingShop.Domain.Entities;
using MediatR;

namespace amazingShop.Domain.Events.Products
{
    public sealed class ProductAddedEvent : Event, INotification
    {
        public Product Added;

        public ProductAddedEvent(Product added)
        {
            Added = added;
        }
    }
}

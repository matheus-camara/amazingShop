using amazingShop.Domain.Core.Events;
using amazingShop.Domain.Entities;
using MediatR;

namespace amazingShop.Domain.Events.Products
{
    public sealed class ProductAddedEvent : Event, INotification
    {
        private Product Added { get; set; }

        public ProductAddedEvent(Product added)
        {
            Added = added;
            SaveData();
        }
    }
}
using amazingShop.Domain.Core.Events;
using amazingShop.Domain.Entities;
using MediatR;

namespace amazingShop.Domain.Events.Products
{
    public sealed class ProductAddedEvent : Event, INotification
    {
        public Product Added { get; private set; }

        public User AddedBy { get; private set; }

        public ProductAddedEvent(Product added)
        {
            Added = added;
            AddedBy = added.AddedBy;
        }

        protected override object GetData() => new
        {
            Added = new
            {
                Added.Name,
                Added.Description,
                Added.ImageUrl,
                Added.Price,
            },
            AddedBy = new
            {
                AddedBy.Id
            }
        };
    }
}
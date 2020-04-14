using amazingShop.Domain.Core.Events;
using amazingShop.Domain.Entities;
using MediatR;

namespace amazingShop.Domain.Events.Products
{
    public sealed class ProductDeletedEvent : Event, INotification
    {
        public Product Deleted { get; private set; }

        public User DeletedBy { get; private set; }

        public ProductDeletedEvent(Product deleted, User deletedBy)
        {
            Deleted = deleted;
            DeletedBy = deletedBy;
        }

        protected override object GetData() => new
        {
            Deleted = new
            {
                Deleted.Name,
                Deleted.Description,
                Deleted.ImageUrl,
                Deleted.Price,
            },
            AddedBy = new
            {
                DeletedBy.Id
            }
        };
    }
}
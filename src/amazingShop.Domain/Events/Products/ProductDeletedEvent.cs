using System.Text.Json;
using amazingShop.Domain.Core.Events;
using amazingShop.Domain.Entities;
using MediatR;

namespace amazingShop.Domain.Events.Products
{
    public sealed class ProductDeletedEvent : Event, INotification
    {
        private Product Deleted { get; set; }

        private User DeletedBy { get; set; }

        public ProductDeletedEvent(Product deleted, User deletedBy)
        {
            Deleted = deleted;
            DeletedBy = deletedBy;
        }
    }
}
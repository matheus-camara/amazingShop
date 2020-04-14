using amazingShop.Domain.Core.Events;
using amazingShop.Domain.Entities;
using MediatR;

namespace amazingShop.Domain.Events.Products
{
    public sealed class ProductEditedEvent : Event, INotification
    {
        public User EditedBy { get; private set; }

        public ProductEditedEvent(User editedBy)
        {
            EditedBy = editedBy;
        }

        protected override object GetData() => new
        {
            EditedBy = new
            {
                EditedBy.Id
            }
        };
    }
}
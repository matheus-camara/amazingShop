using System.Text.Json;
using amazingShop.Domain.Core.Events;
using amazingShop.Domain.Entities;
using MediatR;

namespace amazingShop.Domain.Events.Products
{
    public sealed class ProductEditedEvent : Event, INotification
    {
        private User EditedBy { get; set; }

        private Product PreviousValue { get; set; }

        private Product CurrentValue { get; set; }

        public ProductEditedEvent(User editedBy, Product previousValue, Product currentValue)
        {
            EditedBy = editedBy;
            PreviousValue = previousValue;
            CurrentValue = currentValue;
        }
    }
}
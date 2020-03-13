using System;
using System.Threading;
using System.Threading.Tasks;
using amazingShop.Domain.Core.Events;
using amazingShop.Domain.Events.Products;
using amazingShop.Domain.Repositories;
using MediatR;

namespace amazingShop.Api.EventHandlers.Products
{
    public sealed class ProductAddedEventHandler : INotificationHandler<ProductAddedEvent>
    {
        private readonly IRepository<Event> _eventRepository;

        public async Task Handle(ProductAddedEvent notification, CancellationToken cancellationToken)
        {
            await _eventRepository.AddAsync(notification);
            await _eventRepository.SaveAsync();
        }

        public ProductAddedEventHandler(IRepository<Event> eventRepository) => _eventRepository = eventRepository;
    }
}
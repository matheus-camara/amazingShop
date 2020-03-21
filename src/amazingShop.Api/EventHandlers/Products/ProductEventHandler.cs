using System.Threading;
using System.Threading.Tasks;
using amazingShop.Domain.Core.Events;
using amazingShop.Domain.Events.Products;
using amazingShop.Domain.Repositories;
using MediatR;

namespace amazingShop.Api.EventHandlers.Products
{
    public sealed class ProductEventHandler : INotificationHandler<ProductAddedEvent>
                                            , INotificationHandler<ProductDeletedEvent>
                                            , INotificationHandler<ProductEditedEvent>
    {
        private readonly IRepository<Event> _eventRepository;

        public ProductEventHandler(IRepository<Event> eventRepository) => _eventRepository = eventRepository;

        public async Task Handle(ProductAddedEvent notification, CancellationToken cancellationToken) => await CreateLog(notification);

        public async Task Handle(ProductEditedEvent notification, CancellationToken cancellationToken) => await CreateLog(notification);

        public async Task Handle(ProductDeletedEvent notification, CancellationToken cancellationToken) => await CreateLog(notification);

        private async Task CreateLog(Event notification)
        {
            await _eventRepository.AddAsync(notification);
            await _eventRepository.SaveAsync();
        }
    }
}
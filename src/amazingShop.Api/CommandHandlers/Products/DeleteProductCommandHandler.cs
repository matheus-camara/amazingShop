using System.Threading;
using System.Threading.Tasks;
using amazingShop.Api.Commands.Products;
using amazingShop.Domain.Core.Commands;
using amazingShop.Domain.Core.Notifications;
using amazingShop.Domain.Entities;
using amazingShop.Domain.Events.Products;
using amazingShop.Domain.Repositories;
using MediatR;

namespace amazingShop.Api.CommandHandlers.Products
{
    public sealed class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
    {
        private readonly IRepository<Product> _repository;

        private readonly IMediator _mediator;

        private readonly INotificationFactory _notificationFactory;

        public async Task<DeleteProductCommand> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.FindAsync(request.Id);

            if (result is null)
                return HandleNotFound(request);

            if (result.AddedBy.Id != request.User)
                return HandleNoPermission(request);

            _repository.Delete(result);
            await _repository.SaveAsync();
            await _mediator.Publish(new ProductDeletedEvent(result, result.AddedBy));

            return request;
        }

        public DeleteProductCommand HandleNoPermission(DeleteProductCommand request)
        {
            request.AddNotification(_notificationFactory.Get("USE-008"));
            return request;
        }

        private DeleteProductCommand HandleNotFound(DeleteProductCommand request)
        {
            request.AddNotification(_notificationFactory.Get("APP-001"));
            return request;
        }

        public DeleteProductCommandHandler(IRepository<Product> repository, IMediator mediator, INotificationFactory notificationFactory)
            => (_repository, _mediator, _notificationFactory) = (repository, mediator, notificationFactory);
    }
}
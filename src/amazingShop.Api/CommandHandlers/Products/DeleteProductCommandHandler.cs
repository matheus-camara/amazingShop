using System.Threading;
using System.Threading.Tasks;
using amazingShop.Api.Commands.Products;
using amazingShop.Domain.Core.Commands;
using amazingShop.Domain.Core.Notifications;
using amazingShop.Domain.Entities;
using amazingShop.Domain.Repositories;

namespace amazingShop.Api.CommandHandlers.Products
{
    public sealed class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
    {
        private readonly IRepository<Product> _repository;

        private readonly INotificationFactory _notificationFactory;

        public async Task<DeleteProductCommand> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == default!)
                return HandleNotFound(request);

            var result = await _repository.FindAsync(request.Id);

            if (result == null)
                return HandleNotFound(request);

            _repository.Delete(result);

            return request;
        }

        private DeleteProductCommand HandleNotFound(DeleteProductCommand request)
        {
            request.AddNotification(_notificationFactory.Get("APP-001"));
            return request;
        }

        public DeleteProductCommandHandler(IRepository<Product> repository, INotificationFactory notificationFactory)
            => (_repository, _notificationFactory) = (repository, notificationFactory);
    }
}
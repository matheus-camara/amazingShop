using System.Threading.Tasks;
using amazingShop.Api.Mappers;
using amazingShop.Domain.Core.Commands;
using amazingShop.Domain.Core.Commands.Products;
using amazingShop.Domain.Core.Notifications;
using amazingShop.Domain.Core.Validators;
using amazingShop.Domain.Entities;
using amazingShop.Domain.Events.Products;
using amazingShop.Domain.Repositories;
using amazingShop.Domain.Rules.Products;

namespace amazingShop.Api.CommandHandlers.Products
{
    public sealed class AddProductCommandHandler : ICommandHandler<AddProductCommand>
    {
        private readonly IRepository<Product> _repository;

        private readonly INotificationFactory _notificationFactory;

        private readonly IMapper<AddProductCommand, Product> _mapper;

        public AddProductCommandHandler(IRepository<Product> repository, INotificationFactory notificationFactory, IMapper<AddProductCommand, Product> mapper)
        {
            _repository = repository;
            _notificationFactory = notificationFactory;
            _mapper = mapper;
        }

        public async Task<AddProductCommand> ExecuteAsync(AddProductCommand command)
        {
            var product = _mapper.Map(command);

            new Validator<Product>(product)
                .Add(new AllProductFieldsAreRequiredRule(_notificationFactory.Get("PRO-001")))
                .Run();

            if (product.IsValid)
            {
                await _repository.AddAsync(product);
                await _repository.SaveAsync();
                new ProductAddedEvent(product).Dispatch();
            }
            else
            {
                command.AddNotification(product.Notifications);
            }

            return command;
        }
    }
}
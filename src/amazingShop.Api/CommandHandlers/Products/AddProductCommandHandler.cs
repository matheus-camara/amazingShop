using System.Threading.Tasks;
using amazingShop.Api.Mappers;
using amazingShop.Domain.Core.Commands;
using amazingShop.Domain.Core.Commands.Products;
using amazingShop.Domain.Entities;
using amazingShop.Domain.Events.Products;
using amazingShop.Domain.Repositories;
using amazingShop.Domain.Rules.Products;
using amazingShop.Domain.Validators;

namespace amazingShop.Api.CommandHandlers.Products
{
    public sealed class AddProductCommandHandler : ICommandHandler<AddProductCommand>
    {
        private readonly IRepository<Product> Repository;
        private readonly IMapper<AddProductCommand, Product> Mapper;

        public AddProductCommandHandler(IRepository<Product> repository, IMapper<AddProductCommand, Product> mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public async Task<AddProductCommand> ExecuteAsync(AddProductCommand command)
        {
            var product = Mapper.Map(command);

            Validator<Product>.For(product)
                .Add(new AllProductFieldsAreRequiredRule())
                .Run();

            if (product.IsValid)
            {
                await Repository.AddAsync(product);
                Repository.SaveAsync();
                ProductAddedEvent.Dispatch(product);
            }
            else
            {
                command.AddNotification(product.Notifications);
            }

            return command;
        }
    }
}
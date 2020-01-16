using amazingShop.Domain.Core.Commands.Products;
using amazingShop.Domain.Entities;

namespace amazingShop.Api.Mappers.Products
{
    public sealed class ProductMapper : IMapper<AddProductCommand, Product>
    {
        public Product Map(AddProductCommand command)
            => command is null 
                ? null
                : new Product(name: command.Name, description: command.Description, price: command.Price, imageUrl: command.ImageUrl);
        
    }
}

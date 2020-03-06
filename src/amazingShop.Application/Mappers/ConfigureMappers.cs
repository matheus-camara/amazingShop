using System;
using amazingShop.Application.Commands.Products;
using amazingShop.Application.Dtos;
using amazingShop.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace amazingShop.Application.Mappers
{
    public class ConfigureMappers
    {

        public static void Build(IServiceCollection services)
        {
            services.AddTransient<Func<AddProductCommand, Product>>(p => Map);
            services.AddTransient<Func<Product, ProductDto>>(p => Map);
        }
        public static Product Map(AddProductCommand command)
            => command is null
                ? null
                : new Product(
                    name: command.Name,
                    description: command.Description,
                    price: command.Price,
                    imageUrl: command.ImageUrl);

        public static ProductDto Map(Product command)
            => command is null
                ? null
                : new ProductDto
                {
                    Id = command.Id,
                    ImageUrl = command.ImageUrl,
                    Name = command.Name,
                    Price = command.Price,
                    Description = command.Description
                };
    }
}
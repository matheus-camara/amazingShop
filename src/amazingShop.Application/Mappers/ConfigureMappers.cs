using System;
using amazingShop.Domain.Commands.Products;
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
            services.AddTransient<Func<EditProductCommand, Product>>(p => Map);
            services.AddTransient<Func<Product, ProductDto>>(p => Map);
        }
        public static Product Map(AddProductCommand command)
            => new Product(
                    name: command.Name ?? default!,
                    description: command.Description ?? default!,
                    price: command.Price ?? default!,
                    imageUrl: command.ImageUrl ?? default!);

        public static Product Map(EditProductCommand command)
            => new Product(
                    id: command.Id ?? default!,
                    name: command.Name ?? default!,
                    description: command.Description ?? default!,
                    price: command.Price ?? default!,
                    imageUrl: command.ImageUrl ?? default!);

        public static ProductDto Map(Product command)
            => new ProductDto
            {
                Id = command.Id,
                ImageUrl = command.ImageUrl,
                Name = command.Name,
                Price = command.Price,
                Description = command.Description
            };
    }
}
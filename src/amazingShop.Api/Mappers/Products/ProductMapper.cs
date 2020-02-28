﻿using amazingShop.Api.Dtos;
using amazingShop.Domain.Core.Commands.Products;
using amazingShop.Domain.Entities;

namespace amazingShop.Api.Mappers.Products
{
    public sealed class ProductMapper : IMapper<AddProductCommand, Product>, IMapper<Product, ProductDto>
    {
        public Product Map(AddProductCommand command)
            => command is null 
                ? null
                : new Product(
                    name: command.Name,
                    description: command.Description,
                    price: command.Price,
                    imageUrl: command.ImageUrl);

        public ProductDto Map(Product command)
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

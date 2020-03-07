
using amazingShop.Domain.Core.Commands;
using MediatR;

namespace amazingShop.Application.Commands.Products
{
    public sealed class AddProductCommand : Command, IRequest<AddProductCommand>
    {
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public double Price { get; set; } = default!;

        public string ImageUrl { get; set; } = default!;
    }
}

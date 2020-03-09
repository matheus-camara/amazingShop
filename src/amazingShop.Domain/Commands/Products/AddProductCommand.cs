
using amazingShop.Domain.Core.Commands;
using MediatR;

namespace amazingShop.Domain.Commands.Products
{
    public sealed class AddProductCommand : Command, IRequest<AddProductCommand>
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public double? Price { get; set; }

        public string? ImageUrl { get; set; }
    }
}

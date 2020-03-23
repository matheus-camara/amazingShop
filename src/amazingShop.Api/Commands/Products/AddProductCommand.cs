
using amazingShop.Domain.Core.Commands;
using MediatR;

namespace amazingShop.Api.Commands.Products
{
    public sealed class AddProductCommand : Command, IRequest<AddProductCommand>
    {
        public long? Result { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public double? Price { get; set; }

        public string? ImageUrl { get; set; }
    }
}

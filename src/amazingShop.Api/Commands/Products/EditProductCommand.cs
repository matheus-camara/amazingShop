using amazingShop.Domain.Core.Commands;
using MediatR;

namespace amazingShop.Api.Commands.Products
{
    public sealed class EditProductCommand : Command, IRequest<EditProductCommand>
    {
        public long Id { get; set; } = default!;

        public string? Name { get; set; }

        public string? Description { get; set; }

        public double? Price { get; set; }

        public string? ImageUrl { get; set; }
    }
}
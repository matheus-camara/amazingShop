using amazingShop.Domain.Core.Commands;
using MediatR;

namespace amazingShop.Application.Commands.Products
{
    public class EditProductCommand : Command, IRequest<EditProductCommand>
    {
        public long Id { get; set; } = default!;

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public double Price { get; set; } = default!;

        public string ImageUrl { get; set; } = default!;
    }
}
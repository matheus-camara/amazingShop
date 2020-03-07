using amazingShop.Domain.Core.Commands;
using MediatR;

namespace amazingShop.Application.Commands.Products
{
    public sealed class DeleteProductCommand : Command, IRequest<DeleteProductCommand>
    {
        public long Id { get; set; } = default!;
    }
}
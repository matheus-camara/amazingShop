using amazingShop.Domain.Core.Commands;
using MediatR;

namespace amazingShop.Api.Commands.Products
{
    public sealed class DeleteProductCommand : Command, IRequest<DeleteProductCommand>
    {
        public long User { get; set; } = default!;

        public long Id { get; set; } = default!;
    }
}
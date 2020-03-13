using amazingShop.Domain.Core.Commands;
using MediatR;

namespace amazingShop.Api.Commands.Products
{
    public sealed class GetProductCommand : Command, IRequest<GetProductCommand>
    {
        public long Id { get; set; } = default!;

        public object? Result { get; set; }

        public override bool IsValid => Result != null;
    }
}
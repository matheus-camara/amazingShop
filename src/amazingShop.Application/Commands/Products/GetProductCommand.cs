using amazingShop.Application.Dtos;
using amazingShop.Domain.Core.Commands;
using MediatR;

namespace amazingShop.Application.Commands.Products
{
    public sealed class GetProductCommand : Command, IRequest<GetProductCommand>
    {
        public long Id { get; set; }

        public ProductDto Result { get; set; }

        public override bool IsValid => Result != null;
    }
}
using System.Collections.Generic;
using amazingShop.Application.Dtos;
using amazingShop.Domain.Core.Commands;
using MediatR;

namespace amazingShop.Application.Commands.Products
{
    public sealed class GetProductsCommand : Command, IRequest<GetProductsCommand>, IPaged
    {
        public int Take { get; set; }

        public int Skip { get; set; }

        public long Total { get; set; }

        public IEnumerable<ProductDto> Result { get; set; }

        public override bool IsValid => Result != null;
    }
}
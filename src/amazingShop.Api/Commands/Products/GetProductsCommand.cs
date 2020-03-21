using System.Collections.Generic;
using System.Linq;
using amazingShop.Api.Dtos;
using amazingShop.Domain.Core.Commands;
using MediatR;

namespace amazingShop.Api.Commands.Products
{
    public sealed class GetProductsCommand : Command, IRequest<GetProductsCommand>, IPaged
    {
        public int Take { get; set; } = default!;

        public int Skip { get; set; } = default!;

        public long Total { get; set; } = default!;

        public IEnumerable<ProductDto> Result { get; set; } = Enumerable.Empty<ProductDto>();

        public override bool IsValid => Result?.Any() ?? false;
    }
}
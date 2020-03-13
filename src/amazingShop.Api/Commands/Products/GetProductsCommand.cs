using System.Collections.Generic;
using System.Linq;
using amazingShop.Domain.Core.Commands;
using MediatR;

namespace amazingShop.Api.Commands.Products
{
    public sealed class GetProductsCommand : Command, IRequest<GetProductsCommand>, IPaged
    {
        public int Take { get; set; } = default!;

        public int Skip { get; set; } = default!;

        public long Total { get; set; } = default!;

        public IEnumerable<object>? Result { get; set; }

        public override bool IsValid => Result?.Any() ?? false;
    }
}
namespace amazingShop.Domain.Core.Commands.Products
{
    public sealed class GetProductsCommand : Command, IResult, IPaged
    {
        public int Take { get; set; }

        public int Skip { get; set; }

        public object Result { get; set; }

        public override bool IsValid => Result != null;
    }
}
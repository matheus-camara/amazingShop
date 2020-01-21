namespace amazingShop.Domain.Core.Commands.Products
{
    public sealed class GetProductCommand : Command, IResult
    {
        public long Id { get; set; }

        public object Result { get; set; }

        public override bool IsValid => Result != null;
    }
}
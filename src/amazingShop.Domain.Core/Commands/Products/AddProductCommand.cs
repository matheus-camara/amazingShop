namespace amazingShop.Domain.Core.Commands.Products
{
    public class AddProductCommand : Command
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string ImageUrl { get; set; }
    }
}

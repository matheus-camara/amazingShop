
namespace amazingShop.Domain.Core.Commands.Products
{
    public sealed class AddProductCommand : Command
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ImageUrl { get; set; }
    }
}

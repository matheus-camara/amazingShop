namespace amazingShop.Domain.Entities
{
    public sealed class Product : EntityBase
    {
        public Product(string name, string description, double price, string imageUrl)
        {
            Name = name;
            Description = description;
            Price = price;
            ImageUrl = imageUrl;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public double Price { get; private set; }

        public string ImageUrl { get; private set; }
    }
}

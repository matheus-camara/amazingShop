namespace amazingShop.Domain.Entities
{
    public sealed class Product : EntityBase
    {
        public Product(long id) : base(id) { }

        public Product(string name, string description, double price, string imageUrl) :
            this(0, name, description, price, imageUrl)
        { }

        public Product(long id, string name, string description, double price, string imageUrl) : this(id)
            => (Name, Description, Price, ImageUrl) = (name, description, price, imageUrl);

        public string Name { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public double Price { get; private set; } = default!;

        public string ImageUrl { get; private set; } = default!;

        public void Update(Product updated)
        {
            Name = updated.Name;
            Description = updated.Description;
            Price = updated.Price;
            ImageUrl = updated.ImageUrl;
        }
    }
}

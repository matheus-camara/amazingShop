namespace amazingShop.Domain.Entities
{
    public sealed class Product : EntityBase
    {
        public Product(long id, User addedBy) : base(id)
        {
            AddedBy = addedBy;
        }

        public Product(string name, string description, double price, string imageUrl, User addedBy) :
            this(0, name, description, price, imageUrl, addedBy)
        { }

        public Product(long id, string name, string description, double price, string imageUrl, User addedBy) : this(id, addedBy)
            => (Name, Description, Price, ImageUrl) = (name, description, price, imageUrl);

        public string Name { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public double Price { get; private set; } = default!;

        public string ImageUrl { get; private set; } = default!;

        public User AddedBy { get; }

        public void Update(Product updated)
        {
            Name = updated.Name;
            Description = updated.Description;
            Price = updated.Price;
            ImageUrl = updated.ImageUrl;
        }
    }
}

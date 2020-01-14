namespace amazingShop.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; private set; }

        public double Price { get; private set; }

        public string ImageUrl { get; private set; }
    }
}

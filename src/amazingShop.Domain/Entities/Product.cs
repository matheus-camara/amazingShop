namespace amazingShop.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string ImageUrl { get; private set; }
    }
}

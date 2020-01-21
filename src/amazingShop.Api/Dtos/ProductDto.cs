namespace amazingShop.Api.Dtos
{
    public sealed class ProductDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ImageUrl { get; set; }
    }
}
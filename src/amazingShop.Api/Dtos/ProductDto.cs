namespace amazingShop.Api.Dtos
{
    public sealed class ProductDto
    {
        public long Id { get; set; } = default!;

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public double Price { get; set; } = default!;

        public string ImageUrl { get; set; } = default!;
    }
}
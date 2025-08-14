namespace Catalog.API.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> Category { get; set; } = new();
        public string Description { get; set; } = default!; //! is to avoid warning and tell compiler :I know this might look null now, but it will be set before it’s used
        public string ImageFile { get; set; } = default!;
        public decimal Price { get; set; }
    }
}

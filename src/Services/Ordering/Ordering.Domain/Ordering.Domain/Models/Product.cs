
namespace Ordering.Domain.Models
{
    public class Product : Entity<ProductId>
    {
        public string Name { get; private set; } = default!;
        public decimal Price { get; private set; } = default!;
        public static Product Create(ProductId id, string name, decimal price) {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
            var product = new Product();
            product.Name = name;
            product.Price = price;
            product.Id = id;
            return product;
        }
    }
}

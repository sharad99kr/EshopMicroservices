using BuildingBlocks.CQRS;

namespace Catalog.API.Products.CreateProduct
{
    //API related operations
    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public record CreateProductResponse(Guid Id);
    public class CreateProductEndpoint
    {
    }
}

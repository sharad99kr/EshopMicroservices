
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetProducts
{
    
    //public record GetProductsRequest();
    public record GetProductsResponse(IEnumerable<Product> Products); //This parameter should be same as in GetProductsResult inside GetProductsHandler
    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app) {
            app.MapGet("/products", async (ISender sender) => {
                var result=await sender.Send(new GetProductsQuery());
                var response = result.Adapt<GetProductsResponse>();
                return Results.Ok(response);
            })
            .WithName("GetProducts")
            .Produces<GetProductsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("get products")
            .WithDescription("Get Products");
        }
    }
}

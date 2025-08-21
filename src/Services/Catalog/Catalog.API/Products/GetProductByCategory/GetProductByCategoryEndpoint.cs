
using Catalog.API.Products.GetProductById;
using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.GetProductByCategory
{
    //public record GetProductByCategoryRequest();
    public record GetProductByCategoryResponse(IEnumerable<Product> Products); //This parameter should be same as in GetProductByIdResult inside GetProductByIdHandler

    public class GetProductByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app) {
            app.MapGet("/products/category/{category}", 
                async (string category, ISender sender) => {
                var result = await sender.Send(new GetProductByCategoryQuery(category));
                var response = result.Adapt<GetProductByCategoryResponse>();
                return Results.Ok(response);
            })
            .WithName("GetProductByCategory")
            .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("get product By Category")
            .WithDescription("Get Product By Category");
        }
    }
}

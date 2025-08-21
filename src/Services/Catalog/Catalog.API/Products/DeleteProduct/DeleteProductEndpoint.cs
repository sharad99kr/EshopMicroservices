﻿
using Catalog.API.Products.GetProducts;
using MediatR;

namespace Catalog.API.Products.DeleteProduct
{
    //public record DeleteProductsRequest(Guid Id);
    public record DeleteProductResponse(bool IsSuccess);
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app) {
            app.MapDelete("/products/{id}", async (Guid id, ISender sender) => {
                var result = await sender.Send(new DeleteProductCommand(id));
                var response = result.Adapt<DeleteProductResponse>();
                return Results.Ok(response);
            })
            .WithName("DeleteProducts")
            .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete products")
            .WithDescription("Delete Products");
        }
    }
}

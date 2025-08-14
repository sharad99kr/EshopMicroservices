using BuildingBlocks.CQRS;
using Catalog.API.Models;
using System.Xml.Linq;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
            : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    //Business Logic operations
    internal class CreateProductCommandHandler 
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken) {

            //Business logic to create a product

            //create Product entity from command object
            var product = new Product {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
            };
            //save to database

            //return CreateProductResult result
            return new CreateProductResult(Guid.NewGuid());
        }
    }
}

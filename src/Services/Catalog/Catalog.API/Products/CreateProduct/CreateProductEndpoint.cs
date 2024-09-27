using Carter;

namespace Catalog.API.Products.CreateProduct
{

    public record CreateProductRecord(string Name, string Description, List<string> Categories, string ImageFile, decimal Price);

    public record CreateProductResponse(Guid id);

    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            throw new NotImplementedException();
        }
    }
}

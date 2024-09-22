using MediatR;

namespace Catalog.API.Products.CreateProduct
{

    public record CreateProductCommand(Guid Id, string Name, string Description, List<string> Categories, string ImageFile, decimal Price)
        : IRequest<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //business logic here

            throw new NotImplementedException();
        }
    }
}



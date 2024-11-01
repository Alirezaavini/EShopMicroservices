namespace Catalog.API.Products.GetProductById
{

    public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResultNew>;

//    public record GetProductByIdResult(Product Product);
    public record GetProductByIdResultNew(Product Product);

    internal class GetProductByIdQueryHander(IDocumentSession documentSession)
        : IQueryHandler<GetProductByIdQuery, GetProductByIdResultNew>
    {
        public async Task<GetProductByIdResultNew> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await documentSession.LoadAsync<Product>(query.Id);

            if (product == null)
            {
                throw new ProductNotFoundException();
            }

            return new GetProductByIdResultNew(product);
        }
    }
} 

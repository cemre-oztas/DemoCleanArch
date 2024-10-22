using CleanArch.Application.Repositories.Product;
using MediatR;
using P = CleanArch.Domain.Entities;


namespace CleanArch.Application.Features.Queries.ProductEntityQueries.GetByIdProductEntity;

internal class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
{

    readonly IProductEntityReadRepository _productReadRepository;
    public GetByIdProductQueryHandler(IProductEntityReadRepository productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }

    public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
    {
        P.ProductEntity product = await _productReadRepository.GetByIdAsync(request.Id, false);
        return new()
        {
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock
        };
    }
}
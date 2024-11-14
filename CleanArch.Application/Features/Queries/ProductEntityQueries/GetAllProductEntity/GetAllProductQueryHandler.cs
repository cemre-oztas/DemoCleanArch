using CleanArch.Application.Repositories.Product;
using MediatR;


namespace CleanArch.Application.Features.Queries.ProductEntityQueries.GetAllProductEntity;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
{
    readonly IProductEntityReadRepository _productReadRepository;

    public GetAllProductQueryHandler(IProductEntityReadRepository productReadRepository)
    {
        _productReadRepository = productReadRepository;

    }
    public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
    {


        var totalProductCount = _productReadRepository.GetAll(false).Count();

        var products = _productReadRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size)
            .Select(p => new
            {
                p.Id,
                p.Name,
                p.Stock,
                p.Price,
                p.CreatedDate,
                p.UpdatedDate,
            }).ToList();

        return new()
        {
            Products = products,
            TotalProductCount = totalProductCount
        };
    }
}

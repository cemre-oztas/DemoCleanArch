using CleanArch.Application.Abstractions.Services;
using MediatR;

namespace CleanArch.Application.Features.Queries.BasketEnitityQueries.GetBasketEntityItems;

public class GetBasketItemsQueryHandler : IRequestHandler<GetBasketItemsQueryRequest, List<GetBasketItemsQueryResponse>>
{

    readonly IBasketEntityService _basketService;

    public GetBasketItemsQueryHandler(IBasketEntityService basketService)
    {
        _basketService = basketService;
    }

    public async Task<List<GetBasketItemsQueryResponse>> Handle(GetBasketItemsQueryRequest request, CancellationToken cancellationToken)
    {
        var basketItems = await _basketService.GetBasketItemsAsync();
        return basketItems.Select(ba => new GetBasketItemsQueryResponse
        {
            BasketItemId = ba.Id.ToString(),
            Name = ba.Product.Name,
            Price = ba.Product.Price,
            Quantity = ba.Quantity
        }).ToList();
    }
}

using CleanArch.Application.Abstractions.Services;
using CleanArch.Application.Features.Commands.Basket.AddItemToBasket;
using MediatR;

namespace CleanArch.Application.Features.Commands.Basket.AddItemToBasketEntity;

public class AddItemToBasketEntityCommandHandler : IRequestHandler<AddItemToBasketEntityCommandRequest, AddItemToBasketEntityCommandResponse>
{
    readonly IBasketEntityService _basketService;

    public AddItemToBasketEntityCommandHandler(IBasketEntityService basketService)
    {
        _basketService = basketService;
    }

    public async Task<AddItemToBasketEntityCommandResponse> Handle(AddItemToBasketEntityCommandRequest request, CancellationToken cancellationToken)
    {
        await _basketService.AddItemToBasketAsync(new()
        {
            BasketId = request.BasketId,

        }
        );

        return new();
    }
}


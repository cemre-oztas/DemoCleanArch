using CleanArch.Application.Abstractions.Services;
using MediatR;


namespace CleanArch.Application.Features.Commands.Basket.RemoveBasketItem;

public class RemoveBasketItemEntityCommandHandler : IRequestHandler< RemoveBasketItemEntityCommandRequest, RemoveBasketItemEntityCommandResponse>
{
    readonly IBasketEntityService _basketService;

    public RemoveBasketItemEntityCommandHandler(IBasketEntityService basketService)
    {
        _basketService = basketService;
    }

    public async Task<RemoveBasketItemEntityCommandResponse> Handle(RemoveBasketItemEntityCommandResponse request, CancellationToken cancellationToken)
    {
        await _basketService.RemoveBasketItemAsync(request.BasketItemEntityId);
        return new RemoveBasketItemEntityCommandResponse();
    }

}

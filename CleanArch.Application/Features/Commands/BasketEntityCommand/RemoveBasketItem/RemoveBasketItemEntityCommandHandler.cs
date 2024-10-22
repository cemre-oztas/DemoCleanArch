using CleanArch.Application.Abstractions.Services;
using MediatR;

namespace CleanArch.Application.Features.Commands.BasketEntityCommand.RemoveBasketItem;

public class RemoveBasketItemCommandHandler : IRequestHandler<RemoveBasketItemEntityCommandRequest, RemoveBasketItemEntityCommandResponse>
{
    readonly IBasketEntityService _basketService;

    public RemoveBasketItemCommandHandler(IBasketEntityService basketService)
    {
        _basketService = basketService;
    }

    public async Task<RemoveBasketItemEntityCommandResponse> Handle(RemoveBasketItemEntityCommandRequest request, CancellationToken cancellationToken)
    {
        await _basketService.RemoveBasketItemAsync(request.BasketItemId);
        return new();
    }
}
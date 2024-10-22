using CleanArch.Application.Abstractions.Services;
using MediatR;

namespace CleanArch.Application.Features.Commands.BasketEntityCommand.AddItemToBasketEntity;

public class AddItemToBasketEntityCommandHandler : IRequestHandler<AddItemToBasketCommandRequest, AddItemToBasketEntityCommandResponse>
{
    readonly IBasketEntityService _basketService;

    public AddItemToBasketEntityCommandHandler(IBasketEntityService basketService)
    {
        _basketService = basketService;
    }

    public async Task<AddItemToBasketEntityCommandResponse> Handle(AddItemToBasketCommandRequest request, CancellationToken cancellationToken)
    {
        await _basketService.AddItemToBasketAsync
            (new()
            {
                BasketId = request.ProductId,
                Quantity = request.Quantity
            }
        );

        return new();
    }
}
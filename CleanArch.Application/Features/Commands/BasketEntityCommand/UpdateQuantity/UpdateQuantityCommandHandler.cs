using CleanArch.Application.Abstractions.Services;
using MediatR;

namespace CleanArch.Application.Features.Commands.BasketEntityCommand.UpdateQuantity;

public class UpdateQuantityCommandHandler : IRequestHandler<UpdateQuantityCommandRequest, UpdateQuantityCommandResponse>
{
    readonly IBasketEntityService _basketService;

    public UpdateQuantityCommandHandler(IBasketEntityService basketService)
    {
        _basketService = basketService;
    }

    public async Task<UpdateQuantityCommandResponse> Handle(UpdateQuantityCommandRequest request, CancellationToken cancellationToken)
    {
        await _basketService.UpdateQuantityAsync(new()
        {
            BasketItemId = request.BasketItemId,
            Quantity = request.Quantity
        });

        return new();
    }
}

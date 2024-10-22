using CleanArch.Application.Abstractions.Services;
using MediatR;

namespace CleanArch.Application.Features.Commands.OrderEntityCommand.CreateOrderEntity;

public class CreateOrderEntityCommandHandler : IRequestHandler<CreateOrderEntityCommandRequest, CreateOrderEntityCommandResponse>
{
    readonly IOrderEntityService _orderService;
    readonly IBasketEntityService _basketService;

    public CreateOrderEntityCommandHandler(IOrderEntityService orderService, IBasketEntityService basketService)
    {
        _orderService = orderService;
        _basketService = basketService;
    }

    public async Task<CreateOrderEntityCommandResponse> Handle(CreateOrderEntityCommandRequest request, CancellationToken cancellationToken)
    {
        await _orderService.CreateOrderAsync(new()
        {
            Address = request.Address,
            Description = request.Description,
            BasketId = _basketService.GetUserActiveBasket?.Id.ToString()
        }
        );


        return new();
    }
}
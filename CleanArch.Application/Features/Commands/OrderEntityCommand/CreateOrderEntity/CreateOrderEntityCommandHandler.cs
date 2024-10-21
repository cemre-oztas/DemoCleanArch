namespace CleanArch.Application.Features.Commands.Order.CreateOrder;

public class CreateOrderEntityCommandHandler : IRequestHandler<CreateOrderEntityCommandRequest, CreateOrderEntityCommandResponse>
{
    readonly IOrderService _orderService;
    readonly IBasketService _basketService;
    readonly IOrderHubService _orderHubService;

    public CreateOrderEntityCommandHandler(IOrderService orderService, IBasketService basketService, IOrderHubService orderHubService)
    {
        _orderService = orderService;
        _basketService = basketService;
        _orderHubService = orderHubService;
    }

    public async Task<CreateOrderEntityCommandResponse> Handle(CreateOrderEntityCommandRequest request, CancellationToken cancellationToken)
    {
        await _orderService.CreateOrderAsync(new()
        {
            Address = request.Address,
            Description = request.Description,
            BasketId = _basketService.GetUserActiveBasket?.Id.ToString()
        });

        await _orderHubService.OrderAddedMessageAsync("Heyy, yeni bir sipariş geldi! :) ");

        return new();
    }
}
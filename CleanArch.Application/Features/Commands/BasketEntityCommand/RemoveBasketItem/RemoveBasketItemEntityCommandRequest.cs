
using MediatR;

namespace CleanArch.Application.Features.Commands.Basket.RemoveBasketItem;

public class RemoveBasketItemEntityCommandRequest : IRequest<RemoveBasketItemEntityCommandResponse>
{
    public string BasketItemId { get; set; }
}
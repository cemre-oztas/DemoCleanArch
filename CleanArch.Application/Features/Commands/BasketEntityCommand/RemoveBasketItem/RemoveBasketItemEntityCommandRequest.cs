using MediatR;

namespace CleanArch.Application.Features.Commands.BasketEntityCommand.RemoveBasketItem;

public class RemoveBasketItemEntityCommandRequest : IRequest<RemoveBasketItemEntityCommandResponse>
{
    public string? BasketItemId { get; set; }
    public string? BasketName { get; set; }
}
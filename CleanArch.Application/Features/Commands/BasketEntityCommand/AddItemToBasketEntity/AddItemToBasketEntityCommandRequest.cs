using MediatR;

namespace CleanArch.Application.Features.Commands.BasketEntityCommand.AddItemToBasketEntity;

public class AddItemToBasketCommandRequest : IRequest<AddItemToBasketEntityCommandResponse>
{
    public string ProductId { get; set; }
    public int Quantity { get; set; }
}

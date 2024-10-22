using MediatR;

namespace CleanArch.Application.Features.Commands.BasketEntityCommand.UpdateQuantity;

public class UpdateQuantityCommandRequest : IRequest<UpdateQuantityCommandResponse>
{
    public string BasketItemId { get; set; }
    public int Quantity { get; set; }
}
namespace CleanArch.Application.Features.Commands.Order.CreateOrder;

public class CreateOrderEntityCommandRequest : IRequest<CreateOrderEntityCommandResponse>
{
    public string Description { get; set; }
    public string Address { get; set; }
}

namespace CleanArch.Application.Features.Commands.Order.CompleteOrder;

public class CompleteOrderEntityCommandRequest : IRequest<CompleteOrderEntityCommandResponse>
{
    public string Id { get; set; }
}
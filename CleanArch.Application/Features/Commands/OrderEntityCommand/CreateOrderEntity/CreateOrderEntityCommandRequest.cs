using MediatR;

namespace CleanArch.Application.Features.Commands.OrderEntityCommand.CreateOrderEntity;

public class CreateOrderEntityCommandRequest : IRequest<CreateOrderEntityCommandResponse>
{
    public string Description { get; set; }
    public string Address { get; set; }
}

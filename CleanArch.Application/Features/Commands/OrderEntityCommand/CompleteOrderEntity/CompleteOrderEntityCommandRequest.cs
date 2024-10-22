using MediatR;

namespace CleanArch.Application.Features.Commands.OrderEntityCommand.CompleteOrderEntity;

public class CompleteOrderEntityCommandRequest : IRequest<CompleteOrderEntityCommandResponse>
{
    public string Id { get; set; }
}
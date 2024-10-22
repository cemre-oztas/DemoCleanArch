using CleanArch.Application.Abstractions.Services;
using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Features.Commands.OrderEntityCommand.CompleteOrderEntity;

public class CompleteOrderEntityCommandHandler : IRequestHandler<CompleteOrderEntityCommandRequest, CompleteOrderEntityCommandResponse>
{
    readonly IOrderEntityService _orderService;
    readonly IMailService _mailService;

    public CompleteOrderEntityCommandHandler(IOrderEntityService orderService, IMailService mailService)
    {
        _orderService = orderService;
        _mailService = mailService;
    }

    public async Task<CompleteOrderEntityCommandResponse> Handle(CompleteOrderEntityCommandRequest request, CancellationToken cancellationToken)
    {
        (bool succeeded, CompletedOrderEntity dto) = await _orderService.CompleteOrderAsync(request.Id);
        if (succeeded)
            await _mailService.SendCompletedOrderMailAsync(dto.EMail, dto.OrderCode, dto.OrderDate, dto.Username);
        return new();
    }
}

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

}

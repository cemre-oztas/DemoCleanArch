using CleanArch.Application.Abstractions.Services;
using MediatR;

namespace CleanArch.Application.Features.Queries.OrderEntityQueries.GetOrderById;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQueryRequest, GetOrderByIdQueryResponse>
{
    readonly IOrderEntityService _orderService;

    public GetOrderByIdQueryHandler(IOrderEntityService orderService)
    {
        _orderService = orderService;
    }

    public async Task<GetOrderByIdQueryResponse> Handle(GetOrderByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var data = await _orderService.GetOrderByIdAsync(request.Id);
        return new()
        {
            Id = data.Id,
            OrderCode = data.OrderCode,
            Address = data.Address,
            BasketItems = data.BasketItems,
            CreatedDate = data.CreatedDate,
            Description = data.Description,
            Completed = data.Completed
        };
    }
}
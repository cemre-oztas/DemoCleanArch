using CleanArch.Application.Abstractions.Services;
using MediatR;

namespace CleanArch.Application.Features.Queries.OrderEntityQueries.GetAllOrders;

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQueryRequest, GetAllOrdersQueryResponse>
{
    readonly IOrderEntityService _orderService;

    public GetAllOrdersQueryHandler(IOrderEntityService orderService)
    {
        _orderService = orderService;
    }

    public async Task<GetAllOrdersQueryResponse> Handle(GetAllOrdersQueryRequest request, CancellationToken cancellationToken)
    {
        var data = await _orderService.GetAllOrdersAsync(request.Page, request.Size);

        return new()
        {
            TotalOrderCount = data.TotalOrderCount,
            Orders = data.Orders
        };
    }
}

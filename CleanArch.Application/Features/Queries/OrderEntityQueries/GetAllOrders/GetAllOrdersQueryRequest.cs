﻿using MediatR;

namespace CleanArch.Application.Features.Queries.OrderEntityQueries.GetAllOrders;

public class GetAllOrdersQueryRequest : IRequest<GetAllOrdersQueryResponse>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 5;
}

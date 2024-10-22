using MediatR;

namespace CleanArch.Application.Features.Queries.OrderEntityQueries.GetOrderById;

public class GetOrderByIdQueryRequest : IRequest<GetOrderByIdQueryResponse>
{
    public string Id { get; set; }
}
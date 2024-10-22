namespace CleanArch.Application.Features.Queries.OrderEntityQueries.GetAllOrders;

public class GetAllOrdersQueryResponse
{
    public int TotalOrderCount { get; set; }
    public object Orders { get; set; }
}

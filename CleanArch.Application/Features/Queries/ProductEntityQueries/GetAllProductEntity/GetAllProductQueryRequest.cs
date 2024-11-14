using MediatR;

namespace CleanArch.Application.Features.Queries.ProductEntityQueries.GetAllProductEntity;

public class GetAllProductQueryRequest : IRequest<GetAllProductQueryResponse>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 5;
}
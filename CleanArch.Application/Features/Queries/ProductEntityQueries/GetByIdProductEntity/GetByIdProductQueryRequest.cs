using MediatR;

namespace CleanArch.Application.Features.Queries.ProductEntityQueries.GetByIdProductEntity;

public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
{
    public string Id { get; set; }
}

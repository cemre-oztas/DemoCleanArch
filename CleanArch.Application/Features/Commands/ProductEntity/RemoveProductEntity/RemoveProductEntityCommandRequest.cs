using MediatR;

namespace CleanArch.Application.Features.Commands.ProductEntity.RemoveProductEntity;

public class RemoveProductEntityCommandRequest : IRequest<RemoveProductEntityCommandResponse>
{
    public string Id { get; set; }

}

using MediatR;

namespace CleanArch.Application.Features.Commands.ProductEntity.UpdateProductEntity;

public class UpdateProductEntityCommandRequest : IRequest<UpdateProductEntityCommandResponse>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
}
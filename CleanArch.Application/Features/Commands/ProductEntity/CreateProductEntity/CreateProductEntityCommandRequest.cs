using MediatR;

namespace CleanArch.Application.Features.Commands.ProductEntity.CreateProductEntity;

public class CreateProductEntityCommandRequest : IRequest<CreateProductEntityCommandResponse>
{
    public string? Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
}
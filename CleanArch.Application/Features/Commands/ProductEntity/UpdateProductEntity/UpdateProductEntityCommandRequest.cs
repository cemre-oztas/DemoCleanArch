namespace CleanArch.Application.Features.Commands.Product.UpdateProduct;

public class UpdateProductEntityCommandRequest : IRequest<UpdateProductEntityCommandResponse>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
}
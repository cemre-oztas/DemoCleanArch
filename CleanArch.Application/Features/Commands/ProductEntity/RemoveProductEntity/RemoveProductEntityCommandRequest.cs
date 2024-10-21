namespace CleanArch.Application.Features.Commands.Product.RemoveProduct;

public class RemoveProductEntityCommandRequest : IRequest<RemoveProductEntityCommandResponse>
{
    public string Id { get; set; }
}

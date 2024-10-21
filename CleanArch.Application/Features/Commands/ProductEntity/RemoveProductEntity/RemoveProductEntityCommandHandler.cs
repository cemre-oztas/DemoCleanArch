namespace CleanArch.Application.Features.Commands.Product.RemoveProduct;

public class RemoveProductEntityCommandHandler : IRequestHandler<RemoveProductEntityCommandRequest, RemoveProductEntityCommandResponse>
{
    readonly IProductWriteRepository _productWriteRepository;

    public RemoveProductEntityCommandHandler(IProductWriteRepository productWriteRepository)
    {
        _productWriteRepository = productWriteRepository;
    }

    public async Task<RemoveProductEntityCommandResponse> Handle(RemoveProductEntityCommandRequest request, CancellationToken cancellationToken)
    {
        await _productWriteRepository.RemoveAsync(request.Id);
        await _productWriteRepository.SaveAsync();
        return new();
    }
}

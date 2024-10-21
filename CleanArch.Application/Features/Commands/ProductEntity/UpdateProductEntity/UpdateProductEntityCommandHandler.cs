namespace CleanArch.Application.Features.Commands.Product.UpdateProduct;

public class UpdateProductEntityCommandHandler : IRequestHandler<UpdateProductEntityCommandRequest, UpdateProductEntityCommandResponse>
{
    readonly IProductReadRepository _productReadRepository;
    readonly IProductWriteRepository _productWriteRepository;
    readonly ILogger<UpdateProductEntityCommandHandler> _logger;

    public UpdateProductEntityCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, ILogger<UpdateProductEntityCommandHandler> logger)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
        _logger = logger;
    }

    public async Task<UpdateProductEntityCommandResponse> Handle(UpdateProductEntityCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.ProductEntity product = await _productReadRepository.GetByIdAsync(request.Id);
        product.Stock = request.Stock;
        product.Name = request.Name;
        product.Price = request.Price;
        await _productWriteRepository.SaveAsync();
        _logger.LogInformation("Product güncellendi...");
        return new();
    }
}
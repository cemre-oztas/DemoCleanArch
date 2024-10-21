using CleanArch.Application.Repositories.Product;

namespace CleanArch.Application.Features.Commands.Product.CreateProduct;

public class CreateProductEntityCommandHandler : IRequestHandler<CreateProductEntityCommandRequest, CreateProductEntityCommandResponse>
{
    readonly IProductEntityWriteRepository _productWriteRepository;
    readonly IProductHubService _productHubService;

    public CreateProductEntityCommandHandler(IProductEntityWriteRepository productWriteRepository, IProductHubService productHubService)
    {
        _productWriteRepository = productWriteRepository;
        _productHubService = productHubService;
    }

    public async Task<CreateProductEntityCommandResponse> Handle(CreateProductEntityCommandRequest request, CancellationToken cancellationToken)
    {
        await _productWriteRepository.AddAsync(new()
        {
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock
        });
        await _productWriteRepository.SaveAsync();
        await _productHubService.ProductAddedMessageAsync($"{request.Name} isminde ürün eklenmiştir.");
        return new();
    }
}

using CleanArch.Application.Repositories.Product;
using MediatR;

namespace CleanArch.Application.Features.Commands.ProductEntity.CreateProductEntity;

public class CreateProductEntityCommandHandler : IRequestHandler<CreateProductEntityCommandRequest, CreateProductEntityCommandResponse>
{
    readonly IProductEntityWriteRepository _productWriteRepository;


    public CreateProductEntityCommandHandler(IProductEntityWriteRepository productWriteRepository)
    {
        _productWriteRepository = productWriteRepository;
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
        Console.WriteLine($"{request.Name} isminde ürün eklenmiştir.");

        return new();
    }
}

using CleanArch.Application.Repositories.Product;
using MediatR;

namespace CleanArch.Application.Features.Commands.ProductEntity.UpdateProductEntity;

public class UpdateProductEntityCommandHandler : IRequestHandler<UpdateProductEntityCommandRequest, UpdateProductEntityCommandResponse>
{
    readonly IProductEntityReadRepository _productReadRepository;
    readonly IProductEntityWriteRepository _productWriteRepository;


    public UpdateProductEntityCommandHandler(IProductEntityReadRepository productReadRepository, IProductEntityWriteRepository productWriteRepository)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;

    }

    public async Task<UpdateProductEntityCommandResponse> Handle(UpdateProductEntityCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.ProductEntity product = await _productReadRepository.GetByIdAsync(request.Id);
        product.Stock = request.Stock;
        product.Name = request.Name;
        product.Price = request.Price;
        await _productWriteRepository.SaveAsync();
        return new();
    }
}
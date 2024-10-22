using CleanArch.Application.Repositories.Product;
using MediatR;

namespace CleanArch.Application.Features.Commands.ProductEntity.RemoveProductEntity;

public class RemoveProductEntityCommandHandler : IRequestHandler<RemoveProductEntityCommandRequest, RemoveProductEntityCommandResponse>
{
    readonly IProductEntityWriteRepository _productWriteRepository;

    public RemoveProductEntityCommandHandler(IProductEntityWriteRepository productWriteRepository)
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

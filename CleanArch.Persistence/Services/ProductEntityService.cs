using CleanArch.Application.Abstractions.Services;
using CleanArch.Application.Repositories.Product;
using System.Text.Json;

namespace CleanArch.Persistence.Services

{
    public class ProductEntityService : IProductEntityService
    {
        readonly IProductEntityReadRepository _productReadRepository;
        readonly IProductEntityWriteRepository _productWriteRepository;

        public ProductEntityService(
            IProductEntityReadRepository productReadRepository,
            IProductEntityWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public async Task<object> GetProductDetailsAsync(string productId)
        {
            Domain.Entities.ProductEntity product = await _productReadRepository.GetByIdAsync(productId);
            if (product == null)
                throw new Exception("Product not found");

            var plainObject = new
            {
                product.Id,
                product.Name,                                           
                product.Price,
                product.Stock,
                product.CreatedDate
            };
            string plainText = JsonSerializer.Serialize(plainObject);

            return GetProductDetailsAsync;
        }

        public async Task StockUpdateToProductAsync(string productId, int stock)
        {
            Domain.Entities.ProductEntity product = await _productReadRepository.GetByIdAsync(productId);
            if (product == null)
                throw new Exception("Product not found");

            product.Stock = stock;
            await _productWriteRepository.SaveAsync();
        }
    }
}
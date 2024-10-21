namespace CleanArch.Application.Abstractions.Services;

public interface IProductEntityService
{
    Task StockUpdateToProductAsync(string productId, int stock);
}
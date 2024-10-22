using CleanArch.Application.DTOs.Order;
using CleanArch.DTOs.Order;

namespace CleanArch.Application.Abstractions.Services
{
    public interface IOrderEntityService
    {
        Task CreateOrderAsync(CreateOrderEntity createOrder);
        Task<ListOrderEntity> GetAllOrdersAsync(int page, int size);
        Task<SingleOrderEntity> GetOrderByIdAsync(string id);
        Task<(bool, CompletedOrderEntityDTO)> CompleteOrderAsync(string id);
    }
}

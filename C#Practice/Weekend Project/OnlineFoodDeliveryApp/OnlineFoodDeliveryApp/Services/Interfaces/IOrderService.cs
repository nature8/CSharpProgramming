using OnlineFoodOrder.API.DTOs;
using OnlineFoodOrder.API.Models;

namespace OnlineFoodDeliveryApp.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);

        Task CreateOrderAsync(OrderCreateDto dto);
        Task UpdateStatusAsync(int orderId, string status);
        Task DeleteAsync(int id);
    }
}
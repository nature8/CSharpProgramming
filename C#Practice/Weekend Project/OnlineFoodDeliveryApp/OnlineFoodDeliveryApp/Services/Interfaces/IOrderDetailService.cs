using OnlineFoodOrder.API.DTOs;
using OnlineFoodOrder.API.Models;

namespace OnlineFoodDeliveryApp.Services.Interfaces
{
    public interface IOrderDetailService
    {
        Task<List<OrderDetail>> GetAllAsync();
        Task<OrderDetail?> GetByIdAsync(int id);
        Task AddAsync(OrderDetailCreateDto dto);
        Task UpdateAsync(OrderDetail orderDetail);
        Task DeleteAsync(int id);
    }
}
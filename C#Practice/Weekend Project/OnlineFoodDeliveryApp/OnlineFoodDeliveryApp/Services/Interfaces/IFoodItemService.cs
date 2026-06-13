
using OnlineFoodOrder.API.Models;

namespace OnlineFoodDeliveryApp.Services.Interfaces
{
    public interface IFoodItemService
    {
        Task<List<FoodItem>> GetAllAsync();
        Task<FoodItem?> GetByIdAsync(int id);
        Task AddAsync(FoodItem item);
        Task UpdateAsync(FoodItem item);
        Task DeleteAsync(int id);
    }
}
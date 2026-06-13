
using OnlineFoodOrder.API.Models;

namespace OnlineFoodDeliveryApp.Repositories.Interfaces
{
    public interface IFoodItemRepository
    {
        Task<List<FoodItem>> GetAllAsync();
        Task<FoodItem?> GetByIdAsync(int id);
        Task AddAsync(FoodItem item);
        Task UpdateAsync(FoodItem item);
        Task DeleteAsync(int id);
    }
}
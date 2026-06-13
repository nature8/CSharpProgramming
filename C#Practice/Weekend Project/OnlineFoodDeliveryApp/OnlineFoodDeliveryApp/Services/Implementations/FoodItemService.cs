using OnlineFoodOrder.API.Models;
using OnlineFoodDeliveryApp.Repositories.Interfaces;
using OnlineFoodDeliveryApp.Services.Interfaces;

namespace OnlineFoodDeliveryApp.Services.Implementations
{
    public class FoodItemService : IFoodItemService
    {
        private readonly IFoodItemRepository _foodItemRepository;

        public FoodItemService(IFoodItemRepository foodItemRepository)
        {
            _foodItemRepository = foodItemRepository;
        }

        public async Task<List<FoodItem>> GetAllAsync()
        {
            return await _foodItemRepository.GetAllAsync();
        }

        public async Task<FoodItem?> GetByIdAsync(int id)
        {
            return await _foodItemRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(FoodItem item)
        {
            if (string.IsNullOrWhiteSpace(item.FoodName))
                throw new Exception("Food name is required");

            if (item.Price <= 0)
                throw new Exception("Price must be greater than 0");

            await _foodItemRepository.AddAsync(item);
        }

        public async Task UpdateAsync(FoodItem item)
        {
            if (item.FoodId <= 0)
                throw new Exception("Invalid FoodId");

            await _foodItemRepository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new Exception("Invalid Id");

            await _foodItemRepository.DeleteAsync(id);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using OnlineFoodDeliveryApp.Repositories.Interfaces;
using OnlineFoodOrder.API.Data;
using OnlineFoodOrder.API.Models;

namespace OnlineFoodDeliveryApp.Repositories.Implementations
{
    public class FoodItemRepository : IFoodItemRepository
    {
        private readonly AppDbContext _context;

        public FoodItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<FoodItem>> GetAllAsync()
        {
            return await _context.FoodItems.ToListAsync();
        }

        public async Task<FoodItem?> GetByIdAsync(int id)
        {
            return await _context.FoodItems.FindAsync(id);
        }

        public async Task AddAsync(FoodItem item)
        {
            _context.FoodItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FoodItem item)
        {
            _context.FoodItems.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.FoodItems.FindAsync(id);
            if (item != null)
            {
                _context.FoodItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
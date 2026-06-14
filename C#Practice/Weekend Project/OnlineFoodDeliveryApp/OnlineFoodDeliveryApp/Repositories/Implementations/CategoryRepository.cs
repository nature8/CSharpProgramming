using Microsoft.EntityFrameworkCore;
using OnlineFoodOrder.API.Data;
using OnlineFoodOrder.API.Models;
using OnlineFoodDeliveryApp.Repositories.Interfaces;

namespace OnlineFoodDeliveryApp.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllAsync()
            => await _context.Categories.ToListAsync();

        public async Task<Category?> GetByIdAsync(int id)
            => await _context.Categories.FindAsync(id);

        public async Task AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.Categories.FindAsync(id);
            if (data != null)
            {
                _context.Categories.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}
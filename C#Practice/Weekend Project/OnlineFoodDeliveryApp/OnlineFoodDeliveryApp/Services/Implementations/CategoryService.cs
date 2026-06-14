using OnlineFoodOrder.API.Models;
using OnlineFoodDeliveryApp.Repositories.Interfaces;
using OnlineFoodDeliveryApp.Services.Interfaces;

namespace OnlineFoodDeliveryApp.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Category>> GetAllAsync()
            => _repo.GetAllAsync();

        public Task<Category?> GetByIdAsync(int id)
            => _repo.GetByIdAsync(id);

        public async Task AddAsync(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.CategoryName))
                throw new Exception("Category name is required");

            await _repo.AddAsync(category);
        }

        public Task UpdateAsync(Category category)
            => _repo.UpdateAsync(category);

        public Task DeleteAsync(int id)
            => _repo.DeleteAsync(id);
    }
}
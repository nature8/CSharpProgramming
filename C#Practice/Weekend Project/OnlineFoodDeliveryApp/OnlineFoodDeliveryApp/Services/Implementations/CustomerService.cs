using OnlineFoodOrder.API.Models;
using OnlineFoodDeliveryApp.Repositories.Interfaces;
using OnlineFoodDeliveryApp.Services.Interfaces;

namespace OnlineFoodDeliveryApp.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Customer>> GetAllAsync()
            => _repo.GetAllAsync();

        public Task<Customer?> GetByIdAsync(int id)
            => _repo.GetByIdAsync(id);

        public async Task AddAsync(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.FullName))
                throw new Exception("Name required");

            await _repo.AddAsync(customer);
        }

        public Task UpdateAsync(Customer customer)
            => _repo.UpdateAsync(customer);

        public Task DeleteAsync(int id)
            => _repo.DeleteAsync(id);
    }
}
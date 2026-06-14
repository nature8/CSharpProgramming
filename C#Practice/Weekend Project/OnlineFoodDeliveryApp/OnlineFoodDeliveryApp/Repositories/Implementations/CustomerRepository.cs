using Microsoft.EntityFrameworkCore;
using OnlineFoodOrder.API.Data;
using OnlineFoodOrder.API.Models;
using OnlineFoodDeliveryApp.Repositories.Interfaces;

namespace OnlineFoodDeliveryApp.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllAsync()
            => await _context.Customers.ToListAsync();

        public async Task<Customer?> GetByIdAsync(int id)
            => await _context.Customers.FindAsync(id);

        public async Task AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.Customers.FindAsync(id);
            if (data != null)
            {
                _context.Customers.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}
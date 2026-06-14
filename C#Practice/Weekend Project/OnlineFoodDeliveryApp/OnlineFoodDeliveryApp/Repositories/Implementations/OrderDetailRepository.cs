using Microsoft.EntityFrameworkCore;
using OnlineFoodOrder.API.Data;
using OnlineFoodOrder.API.Models;
using OnlineFoodDeliveryApp.Repositories.Interfaces;

namespace OnlineFoodDeliveryApp.Repositories.Implementations
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly AppDbContext _context;

        public OrderDetailRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDetail>> GetAllAsync()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        public async Task<OrderDetail?> GetByIdAsync(int id)
        {
            return await _context.OrderDetails.FindAsync(id);
        }

        public async Task AddAsync(OrderDetail orderDetail)
        {
            await _context.OrderDetails.AddAsync(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderDetail orderDetail)
        {
            _context.OrderDetails.Update(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.OrderDetails.FindAsync(id);
            if (data != null)
            {
                _context.OrderDetails.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}
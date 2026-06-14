using Microsoft.EntityFrameworkCore;
using OnlineFoodOrder.API.Data;
using OnlineFoodOrder.API.DTOs;
using OnlineFoodOrder.API.Models;
using OnlineFoodDeliveryApp.Repositories.Interfaces;
using OnlineFoodDeliveryApp.Services.Interfaces;

namespace OnlineFoodDeliveryApp.Services.Implementations
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _repo;
        private readonly AppDbContext _context;

        public OrderDetailService(IOrderDetailRepository repo, AppDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        public Task<List<OrderDetail>> GetAllAsync()
            => _repo.GetAllAsync();

        public Task<OrderDetail?> GetByIdAsync(int id)
            => _repo.GetByIdAsync(id);

        public async Task AddAsync(OrderDetailCreateDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (dto.OrderId <= 0)
                throw new Exception("Invalid OrderId");

            if (dto.FoodId <= 0)
                throw new Exception("Invalid FoodId");

            if (dto.Quantity <= 0)
                throw new Exception("Quantity must be greater than 0");

            var order = await _context.Orders.FindAsync(dto.OrderId);
            if (order == null)
                throw new Exception("Order not found");

            var food = await _context.FoodItems
                .FirstOrDefaultAsync(f => f.FoodId == dto.FoodId);

            if (food == null)
                throw new Exception("Food item not found");

            var orderDetail = new OrderDetail
            {
                OrderId = dto.OrderId,
                FoodId = dto.FoodId,
                Quantity = dto.Quantity,
                UnitPrice = food.Price
            };

            await _repo.AddAsync(orderDetail);
        }

        public Task UpdateAsync(OrderDetail orderDetail)
            => _repo.UpdateAsync(orderDetail);

        public Task DeleteAsync(int id)
            => _repo.DeleteAsync(id);
    }
}
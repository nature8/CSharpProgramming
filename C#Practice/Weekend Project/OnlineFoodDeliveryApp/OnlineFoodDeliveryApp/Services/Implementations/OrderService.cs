using Microsoft.EntityFrameworkCore;
using OnlineFoodDeliveryApp.Repositories.Interfaces;
using OnlineFoodDeliveryApp.Services.Interfaces;
using OnlineFoodOrder.API.Data;
using OnlineFoodOrder.API.DTOs;
using OnlineFoodOrder.API.Models;

namespace OnlineFoodDeliveryApp.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly AppDbContext _context;

        public OrderService(IOrderRepository orderRepo, AppDbContext context)
        {
            _orderRepo = orderRepo;
            _context = context;
        }

        public Task<List<Order>> GetAllAsync()
            => _orderRepo.GetAllAsync();

        public Task<Order?> GetByIdAsync(int id)
            => _orderRepo.GetByIdAsync(id);

        //  Order creation logic
        public async Task CreateOrderAsync(OrderCreateDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (dto.CustomerId <= 0)
                throw new Exception("Invalid Customer");

            if (dto.Items == null || !dto.Items.Any())
                throw new Exception("Order must contain at least one item");

            var order = new Order
            {
                CustomerId = dto.CustomerId,
                OrderDate = DateTime.Now,
                Status = "Pending",
                OrderDetails = new List<OrderDetail>()
            };

            decimal total = 0;

            foreach (var item in dto.Items)
            {
                var food = await _context.FoodItems
                    .FirstOrDefaultAsync(f => f.FoodId == item.FoodId);

                if (food == null)
                    throw new Exception($"Invalid Food Item ID: {item.FoodId}");

                var detail = new OrderDetail
                {
                    FoodId = item.FoodId,
                    Quantity = item.Quantity,
                    UnitPrice = food.Price
                };

                total += food.Price * item.Quantity;

                order.OrderDetails.Add(detail);
            }

            order.TotalAmount = total;

            await _orderRepo.AddAsync(order);
        }

        public async Task UpdateStatusAsync(int orderId, string status)
        {
            var order = await _orderRepo.GetByIdAsync(orderId);
            if (order == null)
                throw new Exception("Order not found");

            order.Status = status;

            await _orderRepo.UpdateAsync(order);
        }

        public Task DeleteAsync(int id)
            => _orderRepo.DeleteAsync(id);
    }
}
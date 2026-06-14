using Microsoft.AspNetCore.Mvc;
using OnlineFoodDeliveryApp.Services.Interfaces;
using OnlineFoodOrder.API.DTOs;
using OnlineFoodOrder.API.Models;

namespace OnlineFoodDeliveryApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailService _service;

        public OrderDetailsController(IOrderDetailService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderDetailCreateDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid request");

            await _service.AddAsync(dto);

            return Ok(new
            {
                message = "Order detail created successfully"
            });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] OrderDetail orderDetail)
        {
            await _service.UpdateAsync(orderDetail);
            return Ok(new { message = "Updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok(new { message = "Deleted successfully" });
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrder.API.Models;
using OnlineFoodDeliveryApp.Services.Interfaces;

namespace OnlineFoodDeliveryApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return data == null ? NotFound() : Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            await _service.AddAsync(customer);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Customer customer)
        {
            await _service.UpdateAsync(customer);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
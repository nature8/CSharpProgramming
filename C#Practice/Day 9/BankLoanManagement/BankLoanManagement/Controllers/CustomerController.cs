using BankLoanManagement.API.DTOs.Customer;
using BankLoanManagement.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankLoanManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _service.GetAllCustomersAsync();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _service.GetCustomerByIdAsync(id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateDto dto)
        {
            var customer = await _service.CreateCustomerAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = customer.CustomerId },
                customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            CustomerUpdateDto dto)
        {
            var updated = await _service.UpdateCustomerAsync(id, dto);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteCustomerAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
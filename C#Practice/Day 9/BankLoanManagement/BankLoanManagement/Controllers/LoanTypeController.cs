using BankLoanManagement.API.DTOs.LoanType;
using BankLoanManagement.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankLoanManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanTypesController : ControllerBase
    {
        private readonly ILoanTypeService _service;

        public LoanTypesController(ILoanTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var loanTypes = await _service.GetAllLoanTypesAsync();

            return Ok(loanTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var loanType = await _service.GetLoanTypeByIdAsync(id);

            if (loanType == null)
                return NotFound();

            return Ok(loanType);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LoanTypeCreateDto dto)
        {
            var loanType = await _service.CreateLoanTypeAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = loanType.LoanTypeId },
                loanType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            LoanTypeUpdateDto dto)
        {
            var updated = await _service.UpdateLoanTypeAsync(id, dto);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteLoanTypeAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
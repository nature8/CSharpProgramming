using BankLoanManagement.API.DTOs.LoanApplication;
using BankLoanManagement.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankLoanManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanApplicationsController : ControllerBase
    {
        private readonly ILoanApplicationService _service;

        public LoanApplicationsController(
            ILoanApplicationService service)
        {
            _service = service;
        }

        // GET: api/loanapplications
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var applications =
                await _service.GetAllApplicationsAsync();

            return Ok(applications);
        }

        // GET: api/loanapplications/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var application =
                await _service.GetApplicationByIdAsync(id);

            if (application == null)
                return NotFound("Loan application not found.");

            return Ok(application);
        }

        // POST: api/loanapplications
        [HttpPost]
        public async Task<IActionResult> Create(
            LoanApplicationCreateDto dto)
        {
            var application =
                await _service.CreateApplicationAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = application.ApplicationId },
                application);
        }

        // PUT: api/loanapplications/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            LoanApplicationCreateDto dto)
        {
            var updated =
                await _service.UpdateApplicationAsync(id, dto);

            if (!updated)
                return NotFound("Loan application not found.");

            return Ok("Loan application updated successfully.");
        }

        // DELETE: api/loanapplications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted =
                await _service.DeleteApplicationAsync(id);

            if (!deleted)
                return NotFound("Loan application not found.");

            return Ok("Loan application deleted successfully.");
        }

        // PUT: api/loanapplications/approve/5
        [HttpPut("approve/{id}")]
        public async Task<IActionResult> ApproveLoan(int id)
        {
            var result =
                await _service.ApproveLoanAsync(id);

            if (!result)
                return NotFound("Loan application not found.");

            return Ok("Loan approved successfully.");
        }

        // PUT: api/loanapplications/reject/5
        [HttpPut("reject/{id}")]
        public async Task<IActionResult> RejectLoan(int id)
        {
            var result =
                await _service.RejectLoanAsync(id);

            if (!result)
                return NotFound("Loan application not found.");

            return Ok("Loan rejected successfully.");
        }
    }
}
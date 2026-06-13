using BankLoanManagement.API.Data;
using BankLoanManagement.API.DTOs.EMI;
using BankLoanManagement.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankLoanManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EMIsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EMIsController(AppDbContext context)
        {
            _context = context;
        }

        // =====================================================
        // 1. GET: api/emis
        // =====================================================
        [HttpGet]
        public async Task<IActionResult> GetAllEMIs()
        {
            var emis = await _context.LoanEMIs
                .Select(x => new EMIResponseDto
                {
                    EMIId = x.EMIId,
                    LoanId = x.LoanId,
                    InstallmentNumber = x.InstallmentNumber,
                    DueDate = x.DueDate,
                    EMIAmount = x.EMIAmount,
                    PaidDate = x.PaidDate,
                    PaymentStatus = x.PaymentStatus
                })
                .ToListAsync();

            return Ok(emis);
        }

        // =====================================================
        // 2. GET: api/emis/{id}
        // =====================================================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEMIById(int id)
        {
            var emi = await _context.LoanEMIs
                .Where(x => x.EMIId == id)
                .Select(x => new EMIResponseDto
                {
                    EMIId = x.EMIId,
                    LoanId = x.LoanId,
                    InstallmentNumber = x.InstallmentNumber,
                    DueDate = x.DueDate,
                    EMIAmount = x.EMIAmount,
                    PaidDate = x.PaidDate,
                    PaymentStatus = x.PaymentStatus
                })
                .FirstOrDefaultAsync();

            if (emi == null)
                return NotFound("EMI not found");

            return Ok(emi);
        }

        // =====================================================
        // 3. GET: api/emis/loan/{loanId}
        // =====================================================
        [HttpGet("loan/{loanId}")]
        public async Task<IActionResult> GetEMIsByLoanId(int loanId)
        {
            var emis = await _context.LoanEMIs
                .Where(x => x.LoanId == loanId)
                .Select(x => new EMIResponseDto
                {
                    EMIId = x.EMIId,
                    LoanId = x.LoanId,
                    InstallmentNumber = x.InstallmentNumber,
                    DueDate = x.DueDate,
                    EMIAmount = x.EMIAmount,
                    PaidDate = x.PaidDate,
                    PaymentStatus = x.PaymentStatus
                })
                .ToListAsync();

            return Ok(emis);
        }

        // =====================================================
        // 4. GET: api/emis/customer/{customerId}
        // =====================================================
        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetEMIsByCustomerId(int customerId)
        {
            var emis = await _context.LoanEMIs
                .Include(x => x.Loan)
                .ThenInclude(l => l.LoanApplication)
                .Where(x => x.Loan.LoanApplication.CustomerId == customerId)
                .Select(x => new EMIResponseDto
                {
                    EMIId = x.EMIId,
                    LoanId = x.LoanId,
                    InstallmentNumber = x.InstallmentNumber,
                    DueDate = x.DueDate,
                    EMIAmount = x.EMIAmount,
                    PaidDate = x.PaidDate,
                    PaymentStatus = x.PaymentStatus
                })
                .ToListAsync();

            return Ok(emis);
        }

        // =====================================================
        // 5. PUT: api/emis/pay
        // =====================================================
        [HttpPut("pay")]
        public async Task<IActionResult> PayEMI([FromBody] EMIPaymentDto request)
        {
            var emi = await _context.LoanEMIs
                .FirstOrDefaultAsync(x => x.EMIId == request.EMIId);

            if (emi == null)
                return NotFound("EMI not found");

            if (emi.PaymentStatus == "Paid")
                return BadRequest("EMI already paid");

            emi.PaidDate = request.PaidDate;
            emi.PaymentStatus = "Paid";

            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "EMI paid successfully",
                EMIId = emi.EMIId,
                Status = emi.PaymentStatus
            });
        }
    }
}
using BankLoanManagement.API.Data;
using BankLoanManagement.API.Models;
using BankLoanManagement.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankLoanManagement.API.Repositories.Implementations
{
    public class EMIRepository : IEMIRepository
    {
        private readonly AppDbContext _context;

        public EMIRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LoanEMI>> GetAllAsync()
        {
            return await _context.LoanEMIs
                .Include(e => e.Loan)
                .ToListAsync();
        }

        public async Task<LoanEMI?> GetByIdAsync(int id)
        {
            return await _context.LoanEMIs
                .Include(e => e.Loan)
                .FirstOrDefaultAsync(e => e.EMIId == id);
        }

        public async Task<IEnumerable<LoanEMI>> GetByCustomerIdAsync(int customerId)
        {
            return await _context.LoanEMIs
                .Include(e => e.Loan)
                    .ThenInclude(l => l.LoanApplication)
                .Where(e => e.Loan.LoanApplication.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task AddRangeAsync(List<LoanEMI> emis)
        {
            await _context.LoanEMIs.AddRangeAsync(emis);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LoanEMI emi)
        {
            _context.LoanEMIs.Update(emi);

            await _context.SaveChangesAsync();
        }
    }
}
using BankLoanManagement.API.Data;
using BankLoanManagement.API.Models;
using BankLoanManagement.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankLoanManagement.API.Repositories.Implementations
{
    public class LoanRepository : ILoanRepository
    {
        private readonly AppDbContext _context;

        public LoanRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Loan>> GetAllAsync()
        {
            return await _context.Loans
                .Include(x => x.LoanApplication)
                .ToListAsync();
        }

        public async Task<Loan?> GetByIdAsync(int id)
        {
            return await _context.Loans
                .Include(x => x.LoanApplication)
                .FirstOrDefaultAsync(x => x.LoanId == id);
        }

        public async Task<Loan> AddAsync(Loan loan)
        {
            await _context.Loans.AddAsync(loan);

            await _context.SaveChangesAsync();

            return loan;
        }
    }
}
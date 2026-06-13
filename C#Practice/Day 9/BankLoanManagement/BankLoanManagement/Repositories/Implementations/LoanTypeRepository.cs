using BankLoanManagement.API.Data;
using BankLoanManagement.API.Models;
using BankLoanManagement.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankLoanManagement.API.Repositories.Implementations
{
    public class LoanTypeRepository : ILoanTypeRepository
    {
        private readonly AppDbContext _context;

        public LoanTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LoanType>> GetAllAsync()
        {
            return await _context.LoanTypes.ToListAsync();
        }

        public async Task<LoanType?> GetByIdAsync(int id)
        {
            return await _context.LoanTypes.FindAsync(id);
        }

        public async Task<LoanType> AddAsync(LoanType loanType)
        {
            await _context.LoanTypes.AddAsync(loanType);
            await _context.SaveChangesAsync();

            return loanType;
        }

        public async Task UpdateAsync(LoanType loanType)
        {
            _context.LoanTypes.Update(loanType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(LoanType loanType)
        {
            _context.LoanTypes.Remove(loanType);
            await _context.SaveChangesAsync();
        }
    }
}
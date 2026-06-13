using BankLoanManagement.API.Data;
using BankLoanManagement.API.Models;
using BankLoanManagement.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankLoanManagement.API.Repositories.Implementations
{
    public class LoanApplicationRepository : ILoanApplicationRepository
    {
        private readonly AppDbContext _context;

        public LoanApplicationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LoanApplication>> GetAllAsync()
        {
            return await _context.LoanApplications
                .Include(x => x.Customer)
                .Include(x => x.LoanType)
                .ToListAsync();
        }

        public async Task<LoanApplication?> GetByIdAsync(int id)
        {
            return await _context.LoanApplications
                .FirstOrDefaultAsync(x => x.ApplicationId == id);
        }

        public async Task<LoanApplication?> GetApplicationWithDetailsAsync(int id)
        {
            return await _context.LoanApplications
                .Include(x => x.Customer)
                .Include(x => x.LoanType)
                .FirstOrDefaultAsync(x => x.ApplicationId == id);
        }

        public async Task<LoanApplication> AddAsync(LoanApplication application)
        {
            await _context.LoanApplications.AddAsync(application);

            await _context.SaveChangesAsync();

            return application;
        }

        public async Task UpdateAsync(LoanApplication application)
        {
            _context.LoanApplications.Update(application);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(LoanApplication application)
        {
            _context.LoanApplications.Remove(application);

            await _context.SaveChangesAsync();
        }
    }
}
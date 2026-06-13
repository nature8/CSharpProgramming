using BankLoanManagement.API.Models;
using BankLoanManagement.API.Repositories.Interfaces;
using BankLoanManagement.API.Services.Interfaces;

namespace BankLoanManagement.API.Services.Implementations
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<IEnumerable<Loan>> GetAllLoansAsync()
        {
            return await _loanRepository.GetAllAsync();
        }

        public async Task<Loan?> GetLoanByIdAsync(int id)
        {
            return await _loanRepository.GetByIdAsync(id);
        }

        public async Task<Loan> CreateLoanAsync(Loan loan)
        {
            return await _loanRepository.AddAsync(loan);
        }
    }
}
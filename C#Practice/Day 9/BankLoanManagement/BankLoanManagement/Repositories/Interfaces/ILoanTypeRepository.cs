using BankLoanManagement.API.Models;

namespace BankLoanManagement.API.Repositories.Interfaces
{
    public interface ILoanTypeRepository
    {
        Task<IEnumerable<LoanType>> GetAllAsync();

        Task<LoanType?> GetByIdAsync(int id);

        Task<LoanType> AddAsync(LoanType loanType);

        Task UpdateAsync(LoanType loanType);

        Task DeleteAsync(LoanType loanType);
    }
}
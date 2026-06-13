using BankLoanManagement.API.Models;

namespace BankLoanManagement.API.Repositories.Interfaces
{
    public interface ILoanApplicationRepository
    {
        Task<IEnumerable<LoanApplication>> GetAllAsync();

        Task<LoanApplication?> GetByIdAsync(int id);

        Task<LoanApplication?> GetApplicationWithDetailsAsync(int id);

        Task<LoanApplication> AddAsync(LoanApplication application);

        Task UpdateAsync(LoanApplication application);

        Task DeleteAsync(LoanApplication application);
    }
}
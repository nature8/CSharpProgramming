using BankLoanManagement.API.Models;

namespace BankLoanManagement.API.Services.Interfaces
{
    public interface ILoanService
    {
        Task<IEnumerable<Loan>> GetAllLoansAsync();

        Task<Loan?> GetLoanByIdAsync(int id);

        Task<Loan> CreateLoanAsync(Loan loan);
    }
}
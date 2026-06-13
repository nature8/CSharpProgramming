using BankLoanManagement.API.Models;

namespace BankLoanManagement.API.Repositories.Interfaces
{
    public interface ILoanRepository
    {
        Task<IEnumerable<Loan>> GetAllAsync();

        Task<Loan?> GetByIdAsync(int id);

        Task<Loan> AddAsync(Loan loan);
    }
}
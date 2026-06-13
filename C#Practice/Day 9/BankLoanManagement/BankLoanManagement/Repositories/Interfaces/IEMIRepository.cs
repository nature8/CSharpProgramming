using BankLoanManagement.API.Models;

namespace BankLoanManagement.API.Repositories.Interfaces
{
    public interface IEMIRepository
    {
        Task<IEnumerable<LoanEMI>> GetAllAsync();

        Task<LoanEMI?> GetByIdAsync(int id);

        Task<IEnumerable<LoanEMI>> GetByCustomerIdAsync(int customerId);

        Task AddRangeAsync(List<LoanEMI> emis);

        Task UpdateAsync(LoanEMI emi);
    }
}
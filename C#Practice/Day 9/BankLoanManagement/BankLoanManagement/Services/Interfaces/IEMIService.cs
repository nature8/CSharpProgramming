using BankLoanManagement.API.Models;

namespace BankLoanManagement.API.Services.Interfaces
{
    public interface IEMIService
    {
        Task<IEnumerable<LoanEMI>> GetAllEMIsAsync();

        Task<LoanEMI?> GetEMIByIdAsync(int id);

        Task<IEnumerable<LoanEMI>> GetEMIsByCustomerIdAsync(int customerId);

        Task GenerateEMIScheduleAsync(
            int loanId,
            decimal emiAmount,
            int tenureMonths);

        Task<bool> PayEMIAsync(int emiId);
    }
}
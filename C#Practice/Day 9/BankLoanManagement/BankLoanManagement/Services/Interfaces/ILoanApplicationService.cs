using BankLoanManagement.API.DTOs.LoanApplication;

namespace BankLoanManagement.API.Services.Interfaces
{
    public interface ILoanApplicationService
    {
        Task<IEnumerable<LoanApplicationResponseDto>> GetAllApplicationsAsync();

        Task<LoanApplicationResponseDto?> GetApplicationByIdAsync(int id);

        Task<LoanApplicationResponseDto> CreateApplicationAsync(
            LoanApplicationCreateDto dto);

        Task<bool> UpdateApplicationAsync(
            int id,
            LoanApplicationCreateDto dto);

        Task<bool> DeleteApplicationAsync(int id);

        Task<bool> ApproveLoanAsync(int applicationId);

        Task<bool> RejectLoanAsync(int applicationId);
    }
}
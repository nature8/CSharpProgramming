using BankLoanManagement.API.DTOs.LoanType;

namespace BankLoanManagement.API.Services.Interfaces
{
    public interface ILoanTypeService
    {
        Task<IEnumerable<LoanTypeResponseDto>> GetAllLoanTypesAsync();

        Task<LoanTypeResponseDto?> GetLoanTypeByIdAsync(int id);

        Task<LoanTypeResponseDto> CreateLoanTypeAsync(LoanTypeCreateDto dto);

        Task<bool> UpdateLoanTypeAsync(int id, LoanTypeUpdateDto dto);

        Task<bool> DeleteLoanTypeAsync(int id);
    }
}
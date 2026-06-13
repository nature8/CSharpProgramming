using BankLoanManagement.API.DTOs.LoanType;
using BankLoanManagement.API.Models;
using BankLoanManagement.API.Repositories.Interfaces;
using BankLoanManagement.API.Services.Interfaces;

namespace BankLoanManagement.API.Services.Implementations
{
    public class LoanTypeService : ILoanTypeService
    {
        private readonly ILoanTypeRepository _repository;

        public LoanTypeService(ILoanTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LoanTypeResponseDto>> GetAllLoanTypesAsync()
        {
            var loanTypes = await _repository.GetAllAsync();

            return loanTypes.Select(lt => new LoanTypeResponseDto
            {
                LoanTypeId = lt.LoanTypeId,
                LoanName = lt.LoanName,
                InterestRate = lt.InterestRate,
                MaxLoanAmount = lt.MaxLoanAmount,
                MaxTenureMonths = lt.MaxTenureMonths
            });
        }

        public async Task<LoanTypeResponseDto?> GetLoanTypeByIdAsync(int id)
        {
            var loanType = await _repository.GetByIdAsync(id);

            if (loanType == null)
                return null;

            return new LoanTypeResponseDto
            {
                LoanTypeId = loanType.LoanTypeId,
                LoanName = loanType.LoanName,
                InterestRate = loanType.InterestRate,
                MaxLoanAmount = loanType.MaxLoanAmount,
                MaxTenureMonths = loanType.MaxTenureMonths
            };
        }

        public async Task<LoanTypeResponseDto> CreateLoanTypeAsync(LoanTypeCreateDto dto)
        {
            var loanType = new LoanType
            {
                LoanName = dto.LoanName,
                InterestRate = dto.InterestRate,
                MaxLoanAmount = dto.MaxLoanAmount,
                MaxTenureMonths = dto.MaxTenureMonths
            };

            await _repository.AddAsync(loanType);

            return new LoanTypeResponseDto
            {
                LoanTypeId = loanType.LoanTypeId,
                LoanName = loanType.LoanName,
                InterestRate = loanType.InterestRate,
                MaxLoanAmount = loanType.MaxLoanAmount,
                MaxTenureMonths = loanType.MaxTenureMonths
            };
        }

        public async Task<bool> UpdateLoanTypeAsync(int id, LoanTypeUpdateDto dto)
        {
            var loanType = await _repository.GetByIdAsync(id);

            if (loanType == null)
                return false;

            loanType.LoanName = dto.LoanName;
            loanType.InterestRate = dto.InterestRate;
            loanType.MaxLoanAmount = dto.MaxLoanAmount;
            loanType.MaxTenureMonths = dto.MaxTenureMonths;

            await _repository.UpdateAsync(loanType);

            return true;
        }

        public async Task<bool> DeleteLoanTypeAsync(int id)
        {
            var loanType = await _repository.GetByIdAsync(id);

            if (loanType == null)
                return false;

            await _repository.DeleteAsync(loanType);

            return true;
        }
    }
}
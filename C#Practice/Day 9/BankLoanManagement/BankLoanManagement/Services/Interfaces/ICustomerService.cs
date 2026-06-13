using BankLoanManagement.API.DTOs.Customer;

namespace BankLoanManagement.API.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponseDto>> GetAllCustomersAsync();

        Task<CustomerResponseDto?> GetCustomerByIdAsync(int id);

        Task<CustomerResponseDto> CreateCustomerAsync(CustomerCreateDto dto);

        Task<bool> UpdateCustomerAsync(int id, CustomerUpdateDto dto);

        Task<bool> DeleteCustomerAsync(int id);
    }
}
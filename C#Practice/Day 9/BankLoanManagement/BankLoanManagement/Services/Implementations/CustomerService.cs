using BankLoanManagement.API.DTOs.Customer;
using BankLoanManagement.API.Models;
using BankLoanManagement.API.Repositories.Interfaces;
using BankLoanManagement.API.Services.Interfaces;

namespace BankLoanManagement.API.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CustomerResponseDto>> GetAllCustomersAsync()
        {
            var customers = await _repository.GetAllAsync();

            return customers.Select(c => new CustomerResponseDto
            {
                CustomerId = c.CustomerId,
                FullName = c.FullName,
                Email = c.Email,
                MobileNumber = c.MobileNumber,
                Address = c.Address,
                PANNumber = c.PANNumber,
                AnnualIncome = c.AnnualIncome
            });
        }

        public async Task<CustomerResponseDto?> GetCustomerByIdAsync(int id)
        {
            var customer = await _repository.GetByIdAsync(id);

            if (customer == null)
                return null;

            return new CustomerResponseDto
            {
                CustomerId = customer.CustomerId,
                FullName = customer.FullName,
                Email = customer.Email,
                MobileNumber = customer.MobileNumber,
                Address = customer.Address,
                PANNumber = customer.PANNumber,
                AnnualIncome = customer.AnnualIncome
            };
        }

        public async Task<CustomerResponseDto> CreateCustomerAsync(CustomerCreateDto dto)
        {
            var customer = new Customer
            {
                FullName = dto.FullName,
                Email = dto.Email,
                MobileNumber = dto.MobileNumber,
                Address = dto.Address,
                PANNumber = dto.PANNumber,
                AnnualIncome = dto.AnnualIncome
            };

            await _repository.AddAsync(customer);

            return new CustomerResponseDto
            {
                CustomerId = customer.CustomerId,
                FullName = customer.FullName,
                Email = customer.Email,
                MobileNumber = customer.MobileNumber,
                Address = customer.Address,
                PANNumber = customer.PANNumber,
                AnnualIncome = customer.AnnualIncome
            };
        }

        public async Task<bool> UpdateCustomerAsync(int id, CustomerUpdateDto dto)
        {
            var customer = await _repository.GetByIdAsync(id);

            if (customer == null)
                return false;

            customer.FullName = dto.FullName;
            customer.Email = dto.Email;
            customer.MobileNumber = dto.MobileNumber;
            customer.Address = dto.Address;
            customer.PANNumber = dto.PANNumber;
            customer.AnnualIncome = dto.AnnualIncome;

            await _repository.UpdateAsync(customer);

            return true;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _repository.GetByIdAsync(id);

            if (customer == null)
                return false;

            await _repository.DeleteAsync(customer);

            return true;
        }
    }
}
using EmployeeLeaveManagement.Models;
using EmployeeLeaveManagement.Repositories;
using EmployeeLeaveManagement.Services;

namespace EmployeeLeaveManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _repository.GetAllAsync();
        }
    }
}
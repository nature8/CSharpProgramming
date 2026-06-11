using EmployeeLeaveManagement.Models;
using EmployeeLeaveManagement.Repositories;

namespace EmployeeLeaveManagement.Services;

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

    public async Task<Employee?> GetEmployeeById(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddEmployee(Employee employee)
    {
        await _repository.AddAsync(employee);
    }

    public async Task UpdateEmployee(Employee employee)
    {
        await _repository.UpdateAsync(employee);
    }

    public async Task DeleteEmployee(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
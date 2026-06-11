using EmployeeLeaveManagement.Models;
using EmployeeLeaveManagement.Repositories;

namespace EmployeeLeaveManagement.Services;

public interface IEmployeeService
{
    Task<List<Employee>>GetAllEmployees();

    Task<Employee?>GetEmployeeById(int id);

    Task AddEmployee(Employee employee);

    Task UpdateEmployee(Employee employee);

    Task DeleteEmployee(int id);
}
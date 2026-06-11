using EmployeeLeaveManagement.Models;
using EmployeeLeaveManagement.Services;

namespace EmployeeLeaveManagement.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
    }
}
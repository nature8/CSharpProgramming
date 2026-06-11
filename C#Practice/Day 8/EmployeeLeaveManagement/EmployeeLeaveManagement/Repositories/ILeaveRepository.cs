using EmployeeLeaveManagement.Models;

namespace EmployeeLeaveManagement.Repositories;

public interface ILeaveRepository
{
    Task<List<LeaveRequest>>
    GetAllAsync();

    Task<List<LeaveRequest>>
    GetPendingAsync();

    Task ApplyLeaveAsync(
        LeaveRequest leave);

    Task ApproveAsync(int id);

    Task RejectAsync(int id);

    Task DeleteAsync(int id);
}
using EmployeeLeaveManagement.Models;

namespace EmployeeLeaveManagement.Services;

public interface ILeaveService
{
    Task<List<LeaveRequest>>
    GetAllLeaves();

    Task<List<LeaveRequest>>
    GetPendingLeaves();

    Task ApplyLeave(
        LeaveRequest leave);

    Task ApproveLeave(
        int id);

    Task RejectLeave(
        int id);

    Task DeleteLeave(
        int id);
}
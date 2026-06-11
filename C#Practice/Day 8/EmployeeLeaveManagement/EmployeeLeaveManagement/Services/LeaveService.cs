using EmployeeLeaveManagement.Models;
using EmployeeLeaveManagement.Repositories;

namespace EmployeeLeaveManagement.Services;

public class LeaveService
: ILeaveService
{
    private readonly
    ILeaveRepository
    _repository;

    public LeaveService(
        ILeaveRepository repository)
    {
        _repository
        = repository;
    }

    public async Task<List<LeaveRequest>>
    GetAllLeaves()
    {
        return await
        _repository
        .GetAllAsync();
    }

    public async Task<List<LeaveRequest>>
    GetPendingLeaves()
    {
        return await
        _repository
        .GetPendingAsync();
    }

    public async Task ApplyLeave(
        LeaveRequest leave)
    {
        if (
        leave.EndDate
        <
        leave.StartDate
        )
        {
            throw new
            Exception(
            "End Date cannot be earlier than Start Date");
        }

        await
        _repository
        .ApplyLeaveAsync(
        leave);
    }

    public async Task ApproveLeave(
    int id)
    {
        await
        _repository
        .ApproveAsync(
        id);
    }

    public async Task RejectLeave(
    int id)
    {
        await
        _repository
        .RejectAsync(
        id);
    }

    public async Task DeleteLeave(
    int id)
    {
        await
        _repository
        .DeleteAsync(
        id);
    }
}
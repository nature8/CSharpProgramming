using EmployeeLeaveManagement.Data;
using EmployeeLeaveManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLeaveManagement.Repositories;

public class LeaveRepository
: ILeaveRepository
{
    private readonly
    AppDbContext _context;

    public LeaveRepository(
        AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<LeaveRequest>>
    GetAllAsync()
    {
        return await
        _context.LeaveRequests
        .Include(x => x.Employee)
        .Include(x => x.LeaveType)
        .ToListAsync();
    }

    public async Task<List<LeaveRequest>>
    GetPendingAsync()
    {
        return await
        _context.LeaveRequests
        .Where(
        x => x.Status == "Pending")
        .ToListAsync();
    }

    public async Task ApplyLeaveAsync(
    LeaveRequest leave)
    {
        await _context
        .LeaveRequests
        .AddAsync(leave);

        await _context
        .SaveChangesAsync();
    }

    public async Task ApproveAsync(
    int id)
    {
        var leave =
        await _context
        .LeaveRequests
        .FindAsync(id);

        if (leave != null)
        {
            leave.Status
            = "Approved";

            await _context
            .SaveChangesAsync();
        }
    }

    public async Task RejectAsync(
    int id)
    {
        var leave =
        await _context
        .LeaveRequests
        .FindAsync(id);

        if (leave != null)
        {
            leave.Status
            = "Rejected";

            await _context
            .SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(
    int id)
    {
        var leave =
        await _context
        .LeaveRequests
        .FindAsync(id);

        if (leave != null)
        {
            _context
            .LeaveRequests
            .Remove(leave);

            await _context
            .SaveChangesAsync();
        }
    }
}
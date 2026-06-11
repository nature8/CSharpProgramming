using Microsoft.EntityFrameworkCore;
using EmployeeLeaveManagement.Models;

namespace EmployeeLeaveManagement.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee>
    Employees
    { get; set; }

    public DbSet<LeaveType>
    LeaveTypes
    { get; set; }

    public DbSet<LeaveRequest>
    LeaveRequests
    { get; set; }

    protected override void
    OnModelCreating(
    ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LeaveRequest>()
            .HasOne(x => x.Employee)
            .WithMany(x => x.LeaveRequests)
            .HasForeignKey(
                x => x.EmployeeId);

        modelBuilder.Entity<LeaveRequest>()
            .HasOne(x => x.LeaveType)
            .WithMany(x => x.LeaveRequests)
            .HasForeignKey(
                x => x.LeaveTypeId);
    }
}
using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaveManagement.Models;

public class Employee
{
    public int EmployeeId { get; set; }

    [Required]
    [StringLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Department { get; set; } = string.Empty;

    
    public DateTime JoinDate
    { get; set; }

    public ICollection<LeaveRequest>?
    LeaveRequests
    { get; set; }
}
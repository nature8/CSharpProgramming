using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaveManagement.Models;

public class LeaveRequest
{
    public int LeaveRequestId { get; set; }

    public int EmployeeId { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public string Reason { get; set; } = string.Empty;

    public string Status { get; set; } = "Pending";

    public Employee Employee { get; set; } = new Employee();
}

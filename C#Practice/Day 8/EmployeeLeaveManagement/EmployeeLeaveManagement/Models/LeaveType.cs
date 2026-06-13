using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaveManagement.Models;

public class LeaveType
{
    public int LeaveTypeId { get; set; }

    [Required]
    [StringLength(50)]
    public string LeaveName { get; set; } = string.Empty;

    public ICollection<LeaveRequest>? LeaveRequests { get; set; }
}
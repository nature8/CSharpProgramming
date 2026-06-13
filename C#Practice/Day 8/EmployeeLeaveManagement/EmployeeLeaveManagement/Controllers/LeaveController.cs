using Microsoft.AspNetCore.Mvc;
using EmployeeLeaveManagement.Models;
using EmployeeLeaveManagement.Services;

namespace EmployeeLeaveManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeaveController : ControllerBase
{
    private readonly ILeaveService _service;

    public LeaveController(ILeaveService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult>GetAll()
    {
        return Ok(await _service.GetAllLeaves());
    }

    [HttpGet("pending")]
    public async Task<IActionResult>
    GetPending()
    {
        return Ok(await _service.GetPendingLeaves());
    }

    [HttpPost]
    public async Task<IActionResult>
    ApplyLeave(LeaveRequest leave)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _service.ApplyLeave(leave);

        return Ok("Leave Applied");
    }

    [HttpPut("approve/{id}")]
    public async Task<IActionResult>Approve(int id)
    {
        await _service.ApproveLeave(id);

        return Ok("Leave Approved");
    }

    [HttpPut("reject/{id}")]
    public async Task<IActionResult>Reject(int id)
    {
        await _service.RejectLeave(id);

        return Ok("Leave Rejected");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult>Delete(int id)
    {
        await _service.DeleteLeave(id);

        return Ok("Deleted");
    }
}
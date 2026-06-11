using EmployeeLeaveManagement.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _service;

    public EmployeesController(IEmployeeService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        var employees =
            await _service.GetAllEmployees();

        return Ok(employees);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(Employee employee)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok();
    }

}

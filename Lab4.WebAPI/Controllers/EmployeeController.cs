using Lab2.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IDepartmentRepository _repo;

    public EmployeeController(IDepartmentRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    [Route("{employeeId}")]
    public IActionResult GetEmployee(int employeeId)
    {
        try
        {
            var employee = _repo.GetEmployeeById(employeeId);

            return Ok(employee);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
    }
}

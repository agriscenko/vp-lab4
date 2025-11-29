using Lab2.DataAccess;
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
    public Employee[] GetEmployees()
    {
        var data = _repo.GetAllEmployees();

        return data.ToArray();
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

    [HttpGet]
    [Route("FirstName/{employeeFirstName}")]
    public IActionResult GetEmployeesByFirstName(string employeeFirstName)
    {
        try
        {
            var employees = _repo.GetEmployeesByFirstName(employeeFirstName);

            return Ok(employees);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult PostEmployee(Employee employee)
    {
        var id = _repo.AddEmployee(employee);

        return Created($"api/Employee/{id}", id);
    }

    [HttpPut]
    [Route("{emloyeeId}")]
    public IActionResult PutEmployee(Employee employee, int emloyeeId)
    {
        if (employee.Id != emloyeeId)
        {
            return BadRequest();
        }

        try
        {
            var d = _repo.UpdateEmployee(employee);

            return Ok(d);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
    }

    [HttpDelete]
    [Route("{employeeId}")]
    public IActionResult DeleteEmployee(int employeeId)
    {
        try
        {
            _repo.DeleteEmployee(employeeId);

            return Ok();
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    [Route("{employeeId}/LeaveRequests")]
    public IActionResult GetEmployeeLeaveRequests(int employeeId)
    {
        try
        {
            var leaveRequests = _repo.GetEmployeeLeaveRequests(employeeId);

            return Ok(leaveRequests);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
    }
}

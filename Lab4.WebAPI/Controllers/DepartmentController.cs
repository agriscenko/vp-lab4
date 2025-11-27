using Lab2.DataAccess;
using Lab2.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentRepository _repo;

    public DepartmentController(IDepartmentRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public Department[] GetDepartments()
    {
        var data = _repo.GetAll();

        return data.ToArray();
    }

    [HttpGet]
    [Route("{departmentId}")]
    public IActionResult GetDepartment(int departmentId)
    {
        try
        {
            var department = _repo.GetById(departmentId);

            return Ok(department);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    [Route("{departmentId}/Employees")]
    public IActionResult GetEmployees(int departmentId)
    {
        try
        {
            var employees = _repo.GetEmployees(departmentId);

            return Ok(employees);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult PostDepartment(Department department)
    {
        var id = _repo.Add(department);

        return Created($"api/Department/{id}", id);
    }

    [HttpPut]
    [Route("{departmentId}")]
    public IActionResult PutDepartment(Department department, int departmentId)
    {
        if (department.Id != departmentId)
        {
            return BadRequest();
        }

        try
        {
            var d = _repo.Update(department);

            return Ok(d);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
    }

    [HttpDelete]
    [Route("{departmentId}")]
    public IActionResult DeleteDepartment(int departmentId)
    {
        try
        {
            _repo.Delete(departmentId);

            return Ok();
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
    }
}
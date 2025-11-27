using Lab2.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly DepartmentDbContext _db;

    public DepartmentController()
    {
        _db = new DepartmentDbContext();
    }

    [HttpGet]
    public Department[] GetDepartments()
    {
        var data = _db.Departments.ToArray();

        return data;
    }

    [HttpGet("{id}")]
    public Department GetDepartment(int id)
    {
        var data = _db.Departments.FirstOrDefault(d => d.Id == id);

        return data;
    }

    [HttpPost]
    public void Post([FromBody] Department department)
    {
        _db.Departments.Add(department);
        _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void DeleteDepartment(int id)
    {
        var data = _db.Departments.FirstOrDefault(d => d.Id == id);

        if (data != null)
        {
            _db.Departments.Remove(data);
            _db.SaveChanges();
        }
    }

    [HttpPut("{id}")]
    public void UpdateDepartment([FromBody] Department department, int id)
    {
        var existingDepartment = _db.Departments.FirstOrDefault(d => d.Id == id);

        if (existingDepartment != null)
        {
            existingDepartment.Name = department.Name;
            existingDepartment.Code = department.Code;
            existingDepartment.FloorNumber = department.FloorNumber;
            existingDepartment.PhoneNumber = department.PhoneNumber;
            existingDepartment.Email = department.Email;
            existingDepartment.IsHiring = department.IsHiring;
            existingDepartment.LastAuditDateTime = department.LastAuditDateTime;
            existingDepartment.Description = department.Description;
        }

        _db.SaveChanges();
    }
}

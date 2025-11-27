using Lab2.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveRequestController : ControllerBase
{
    private readonly IDepartmentRepository _repo;

    public LeaveRequestController(IDepartmentRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    [Route("{leaveRequestId}")]
    public IActionResult GetLeaveRequest(int leaveRequestId)
    {
        try
        {
            var leaveRequest = _repo.GetLeaveRequestById(leaveRequestId);

            return Ok(leaveRequest);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
    }
}

using Lab2.DataAccess;
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
    public LeaveRequest[] GetLeaveRequests()
    {
        var data = _repo.GetAllLeaveRequests();

        return data.ToArray();
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

    [HttpGet]
    [Route("Type/{leaveRequestType}")]
    public IActionResult GetleaveRequestTypeByType(string leaveRequestType)
    {
        try
        {
            var leaveRequests = _repo.GetLeaveRequestsByType(leaveRequestType);

            return Ok(leaveRequests);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult PostLeaveRequest(LeaveRequest leaveRequest)
    {
        var id = _repo.AddLeaveRequest(leaveRequest);

        return Created($"api/LeaveRequest/{id}", id);
    }

    [HttpPut]
    [Route("{leaveRequestId}")]
    public IActionResult PutLeaveRequest(LeaveRequest leaveRequest, int leaveRequestId)
    {
        if (leaveRequest.Id != leaveRequestId)
        {
            return BadRequest();
        }

        try
        {
            var d = _repo.UpdateLeaveRequest(leaveRequest);

            return Ok(d);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
    }

    [HttpDelete]
    [Route("{leaveRequestId}")]
    public IActionResult DeleteLeaveRequest(int leaveRequestId)
    {
        try
        {
            _repo.DeleteLeaveRequest(leaveRequestId);

            return Ok();
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
    }
}

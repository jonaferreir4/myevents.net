
using Application.UseCases.Attendance.Delete;
using Application.UseCases.Attendance.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("{activityId:long}/[controller]")]
[Authorize]
public class AttendanceController(
    IRegisterAttendanceUC registerAttendanceUC,
    IDeleteAttendanceUC deleteAttendanceUC) : ControllerBase
{
    private readonly IRegisterAttendanceUC _registerAttendanceUC = registerAttendanceUC;
    private readonly IDeleteAttendanceUC _deleteAttendanceUC = deleteAttendanceUC;

    [HttpPost("")]
    public async Task<IActionResult> RegisterAttendance(long activityId)
    {
        var result = await _registerAttendanceUC.RegisterAttendance(activityId);
        return CreatedAtAction(nameof(RegisterAttendance), new { id = result.Id }, result);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAttendance(long id, long activityId)
    {
        var result = await _deleteAttendanceUC.DeleteAttendance(id, activityId);
        return Ok(result);
    }
}

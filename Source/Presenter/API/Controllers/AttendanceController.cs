
using Application.UseCases.Attendance.Delete;
using Application.UseCases.Attendance.Register;
using Application.UseCases.Attendance.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("{activityId:long}/[controller]")]
[Authorize]
public class AttendanceController(
    IRegisterAttendanceUC registerAttendanceUC,
    IDeleteAttendanceUC deleteAttendanceUC,
    IUpdateAttendanceUC updateAttendanceUC
    ) : ControllerBase
{
    private readonly IRegisterAttendanceUC _registerAttendanceUC = registerAttendanceUC;
    private readonly IDeleteAttendanceUC _deleteAttendanceUC = deleteAttendanceUC;

    private readonly IUpdateAttendanceUC _updateAttendanceUC = updateAttendanceUC;

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


    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateAttendance(long id)
    {
        var result = await _updateAttendanceUC.UpdateAttendance(id);
        return Ok(result);
    }
}

using Application.UseCases.Event.Delete;
using Application.UseCases.Event.Register;
using Application.UseCases.Event.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[Controller]")]
public sealed class EventController : ControllerBase
{
  [HttpPost("")]
  public async Task<IActionResult> Register(
    [FromServices] IRegisterEventUC uc,
    [FromBody] RegisterEventRequest request)
  {
    var response = await uc.RegisterEvent(request);
    return Created(string.Empty, response);
  }

  [Authorize]
  [HttpDelete("{id:long}")]
  [ProducesResponseType(typeof(DeleteEventResponse), StatusCodes.Status200OK)]
  public async Task<IActionResult> Delete(
    [FromServices] IDeleteEventUC uc,
    [FromRoute] long id
  )
  {
    var response = await uc.DeleteEvent(id);
    return Ok(response);
  }

  [HttpPut("{id:long}")]
  [ProducesResponseType(typeof(UpdateEventResponse), StatusCodes.Status200OK)]
  public async Task<IActionResult> Update(
    [FromServices] IUpdateEventUC uc,
    [FromBody] UpdateEventRequest request,
    [FromRoute] long id
  )
  {
    var response = await uc.UpdateEvent(id, request);
    return Ok(response);
  }
}

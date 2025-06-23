using Application.UseCases.Event.Delete;
using Application.UseCases.Event.FindByFilters;
using Application.UseCases.Event.FindById;
using Application.UseCases.Event.Register;
using Application.UseCases.Event.Update;
using Library.Http.DTO;
using Library.Http.Requests.Event;
using Library.Http.Responses.Event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[Controller]")]
public sealed class EventController : ControllerBase
{

  [HttpGet("")]
    public async Task<IActionResult> FindByFilter(
      [FromServices] IFindEventsByFiltersUC uc,
      [FromQuery] EventFilter filter

    )
    {
      var response = await uc.FindEventsByFiltersAsync(filter);
      return Ok(response);
    }

  [HttpGet("{id:long}")]
  public async Task<IActionResult> FindById(
    [FromServices] IFindEventByIdUC uc,
    [FromRoute] long id
  )
  {
    var response = await uc.FindEventById(id);
    return Ok(response);
  }
  
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

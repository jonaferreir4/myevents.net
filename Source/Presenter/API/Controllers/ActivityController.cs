using Application.UseCases.Activity.Delete;
using Application.UseCases.Activity.Register;
using Application.UseCases.Activity.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("Event/{eventId:long}/[Controller]")]
public class ActivityController : ControllerBase
{
    [HttpPost("")]
    [ProducesResponseType(typeof(RegisterActivityResponse), StatusCodes.Status201Created)]

    [Authorize]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterActivityUC uc,
        [FromBody] RegisterActivityRequest request,
        [FromRoute] long eventId
    )
    {
        var response = await uc.RegisterActivity(eventId, request);
        return Created(string.Empty, response);
    }

    [Authorize]
    [HttpDelete("{id:long}")]
    [ProducesResponseType(typeof(DeleteActivityResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(
        [FromServices] IDeleteActivityUC uc,
        [FromRoute] long id,
        [FromRoute] long eventId
    )
    {
        var response = await uc.DeleteActivity(eventId, id);
        return Ok(response);
    }

    [HttpPut("{id:long}")]
    [ProducesResponseType(typeof(UpdateActivityResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(
        [FromServices] IUpdateActivityUC uc,
        [FromBody] UpdateActivityRequest request,
        [FromRoute] long id,
        [FromRoute] long eventId
    )
    {
        var response = await uc.UpdateActivity(eventId, id, request);
        return Ok(response);
    }


}

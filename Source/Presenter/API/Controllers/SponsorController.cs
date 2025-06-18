using Application.UseCases.Sponsor.Delete;
using Application.UseCases.Sponsor.Register;
using Application.UseCases.Sponsor.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;

[ApiController]
[Route("[Controller]")]
public class SponsorController : Controller
{
    
     [HttpPost("")]
    public async Task<IActionResult> Register
    (
        [FromServices] IRegisterSponsorUC uc,
        [FromBody] RegisterSponsorRequest request
    )
    {
        var response = await uc.RegisterSponsor(request);
        return Created(string.Empty, response);
    }



    [Authorize]
    [HttpDelete("{id:long}")]
    [ProducesResponseType(typeof(DeleteSponsorResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(
    [FromServices] IDeleteSponsorUC uc,
    long id
    )
    {
        var response = await uc.DeleteSponsor(id);
        return Ok(response);
    }

    [Authorize]
    [HttpPut("{id:long}")]
    [ProducesResponseType(typeof(UpdateSponsorResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(
        [FromServices] IUpdateSponsorUC uc,
        [FromBody] UpdateSponsorRequest request,
        long id
    )
    {
        var response = await uc.UpdateSponsor(id, request);
        return Ok(response);
    }
}

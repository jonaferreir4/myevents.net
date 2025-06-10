using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.UseCases.Inscription.Register;
using Application.UseCases.Inscription.Delete;

namespace API.Controllers;

[ApiController]
[Route("{eventId:long}/[controller]")]
[Authorize]
public class InscriptionController(
    IRegisterInscriptionUC registerInscriptionUC,
    IDeleteInscriptionUC deleteInscriptionUC) : ControllerBase
{
    private readonly IRegisterInscriptionUC _registerInscriptionUC = registerInscriptionUC;
    private readonly IDeleteInscriptionUC _deleteInscriptionUC = deleteInscriptionUC;

    [HttpPost("")]
    public async Task<IActionResult> RegisterInscription(long eventId)
    {
        var result = await _registerInscriptionUC.RegisterInscription(eventId);
        return CreatedAtAction(nameof(RegisterInscription), new { id = result.Id }, result);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteInscription(long id, long eventId)
    {
        var result = await _deleteInscriptionUC.DeleteInscription(id, eventId);
        return Ok(result);
    }
}

using Application.UseCases.Certificate.FindById;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class CertificateController : Controller
{
    [HttpGet("{id:long}")]
    public async Task<IActionResult> FindById(
    [FromServices] IFindCertificateByIdUC uc,
    [FromRoute] long id
        )
    {
        
        var certificates = await uc.FindCertificateByIdAsync(id);
        return Ok(certificates);
    }
}
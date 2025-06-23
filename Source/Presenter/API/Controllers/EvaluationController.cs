using Application.UseCases.Evaluation.Delete;
using Application.UseCases.Evaluation.Register;
using Application.UseCases.Evaluation.Update;
using Library.Http.Requests.Evaluation;
using Library.Http.Responses.Evaluation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("{activityId:long}/[controller]")]
// [Authorize]
public class EvaluationController : Controller
{
  
  [HttpPost("")]
  public async Task<IActionResult> Register(
    [FromServices] IRegisterEvaluationUC uc,
    [FromBody] RegisterEvaluationRequest request)
  {
    var response = await uc.RegisterEvaluation(request);
    return Created(string.Empty, response);
  }

  [HttpDelete("{id:long}")]
  [ProducesResponseType(typeof(DeleteEvaluationResponse), StatusCodes.Status200OK)]
  public async Task<IActionResult> Delete(
    [FromServices] IDeleteEvaluationUC uc,
    [FromRoute] long id
  )
  {
    var response = await uc.DeleteEvaluation(id);
    return Ok(response);
  }

  [HttpPut("{id:long}")]
  [ProducesResponseType(typeof(UpdateEvaluationResponse), StatusCodes.Status200OK)]
  public async Task<IActionResult> Update(
    [FromServices] IUpdateEvaluationUC uc,
    [FromBody] UpdateEvaluationRequest request,
    [FromRoute] long id
  )
  {
    var response = await uc.UpdateEvaluation(request, id);
    return Ok(response);
  }
}

using API.Services;
using Application.UseCases.User.Delete;
using Application.UseCases.User.Login;
using Application.UseCases.User.Register;
using Application.UseCases.User.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[Controller]")]
public sealed class UserController(TokenService service): ControllerBase
{

    [HttpPost("")]
    public async Task<IActionResult> Register
    (
        [FromServices] IRegisterUserUC uc,
        [FromBody] RegisterUserRequest request
    )
    {
        var response = await uc.RegisterUser(request);
        return Created(string.Empty, response);
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login(
        [FromServices] ILoginUserUC uc,
        [FromBody] LoginUserRequest request
    )
    {
        var result = await uc.LoginUser(request);
        var token = service.GenerateJwtToken(result);

        var response = new TokenResponse(result.Id, token);
        return Ok(response);
    }


    [Authorize]
    [HttpDelete("")]
    [ProducesResponseType(typeof(DeleteUserResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(
    [FromServices] IDeleteUserUC uc,
    long id
    )
    {
        var response = await uc.DeleteUser();
        return Ok(response);
    }

    [Authorize]
    [HttpPut("{id:long}")]
    [ProducesResponseType(typeof(UpdateUserResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(
        [FromServices] IUpdateUserUC uc,
        [FromBody] UpdateUserRequest request,
        long id
    )
    {
        var response = await uc.UpdateUser(request);
        return Ok(response);
    }

}
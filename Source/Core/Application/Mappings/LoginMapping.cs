
using Domain.Entities;
using Library.Http.Responses.User;

namespace Application.Mappings;

public static class LoginMapping
{
    public static LoginUserResponse ToResponse(this User user)
    {
        return new LoginUserResponse(
        Id: user.Id,
        Name: user.Name!,
        Email: user.Email!
    );
    }
}
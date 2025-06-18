
using Library.Http.Requests.User;
using Library.Http.Responses.User;

namespace Application.UseCases.User.Login;
    public interface ILoginUserUC
    {
    Task<LoginUserResponse> LoginUser(LoginUserRequest request); 
    }

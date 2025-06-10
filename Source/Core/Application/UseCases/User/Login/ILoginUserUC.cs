
namespace Application.UseCases.User.Login;
    public interface ILoginUserUC
    {
    Task<LoginUserResponse> LoginUser(LoginUserRequest request); 
    }

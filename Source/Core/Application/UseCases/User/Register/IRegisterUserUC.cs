
namespace Application.UseCases.User.Register;
    public interface IRegisterUserUC
    {
        public Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request);
    }

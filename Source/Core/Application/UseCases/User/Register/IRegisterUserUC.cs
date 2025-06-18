
using Library.Http.Requests.User;
using Library.Http.Responses.User;

namespace Application.UseCases.User.Register;
    public interface IRegisterUserUC
    {
        public Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request);
    }

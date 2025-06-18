
using Library.Http.Requests.User;
using Library.Http.Responses.User;

namespace Application.UseCases.User.Update;
    public interface IUpdateUserUC
    {
        public Task<UpdateUserResponse> UpdateUser(UpdateUserRequest request);
    }

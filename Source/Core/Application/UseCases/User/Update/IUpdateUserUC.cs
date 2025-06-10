
namespace Application.UseCases.User.Update;
    public interface IUpdateUserUC
    {
        public Task<UpdateUserResponse> UpdateUser(UpdateUserRequest request);
    }

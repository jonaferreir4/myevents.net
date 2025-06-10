using Domain.Contracts.Data.Repositories.User;
using Domain.Contracts.Data.Services;
using Library.Utils.Authorization;

namespace Application.UseCases.User.Delete;
public class DeleteUserUC(
    IUserWriteRepository  writeRepo,
    IUserReadRepository readRepo,
    IHttpContextAccessor httpContextAccessor,
    IUnitOfWork unitOfWork
) : IDeleteUserUC
{


    public async Task<DeleteUserResponse> DeleteUser()
    {
       
        var userContextId = AuthorizationHelper.GetAuthenticatedUserId(httpContextAccessor);
        

        if (userContextId <= 0)
            throw new UnauthorizedAccessException(" You are not authorized to delete a user.");

        var userExists = await readRepo.FindByIdAsync(userContextId);
        if (userExists == null)
        {
            throw new KeyNotFoundException("User not found.");
        }

        await writeRepo.DeleteAsync(userContextId);
        await unitOfWork.CommitAsync();
        return new DeleteUserResponse(userContextId);
    }
}
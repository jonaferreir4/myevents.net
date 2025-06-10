

using Application.Mappings;
using Application.Services;
using Domain.Contracts.Data.Repositories.User;
using Domain.Contracts.Data.Services;
using Library.Utils.Authorization; // Add this if NotFoundException is in System or for Exception base class

namespace Application.UseCases.User.Update;

public class UpdateUserUC(
    IUserWriteRepository  writeRepo,
    IUserReadRepository readRepo,
    IUnitOfWork unitOfWork,
    IHttpContextAccessor httpContextAccessor

) : IUpdateUserUC
{


    public async Task<UpdateUserResponse> UpdateUser(UpdateUserRequest request)
    {
        var userId = AuthorizationHelper.GetAuthenticatedUserId(httpContextAccessor);

        if  (userId <= 0)
            throw new UnauthorizedAccessException("You are not authorized create a activity.");

        var user = await readRepo.FindByIdAsync(userId)
            ?? throw new Exception($"usuário com o id {userId} não foi encontrado");    
        
        var mapUser = request.ToEntity(user);

        await writeRepo.UpdateAsync(mapUser);
        await unitOfWork.CommitAsync();

        return new UpdateUserResponse(request.Name);
    }

}
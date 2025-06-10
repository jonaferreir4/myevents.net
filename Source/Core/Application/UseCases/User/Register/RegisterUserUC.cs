

using Application.Mappings;
using Application.Services;
using Domain.Contracts.Data.Repositories.User;
using Domain.Contracts.Data.Services;

namespace Application.UseCases.User.Register;

public class RegisterUserUC(
    IUserWriteRepository  writeRepo,
    IUserReadRepository readRepo,
    IUnitOfWork unitOfWork,
    PasswordEncryptionService passwordService


) : IRegisterUserUC
{


    public async Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request)
    {
        var user = request.ToEntity(passwordService.Encrypt(request.Password));

        if (user.Email == null)
            throw new ArgumentNullException(nameof(user.Email), "Email cannot be null");

        if (readRepo.FindActiveEmailAsync(user.Email).Result)
            throw new Exception("Email already registered");

        await writeRepo.CreateAsync(user);
        await unitOfWork.CommitAsync();

        return user.ToRegisterUseResponse();

    }
}
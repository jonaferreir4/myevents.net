using Application.Mappings;
using Application.Services;
using Domain.Contracts.Data.Repositories.User;


namespace Application.UseCases.User.Login;
public class LoginUserUC(

    IUserReadRepository readRepo,
    PasswordEncryptionService PwdService
) : UseCase<LoginUserRequest>(new LoginUserValidator()), ILoginUserUC
{
    public async Task<LoginUserResponse> LoginUser(LoginUserRequest request)
    {
        var user = await readRepo.FindByEmailAsync(request.Email) ?? throw new Exception("User not found!");

        return user.ToResponse();
    
    }
    
    protected override async Task<string> ApplyExtraValidationAsync(LoginUserRequest request)
    {
        var password = PwdService.Encrypt(request.Password);
        var user = await readRepo.FindByEmailAsync(request.Email);

        return password != user?.Password
            ? "The credentials provided aren't valid!"
            : string.Empty;
    }
}

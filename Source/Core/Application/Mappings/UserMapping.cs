
using Application.UseCases.User.Register;
using Application.UseCases.User.Update;
using Domain.Entities;

namespace Application.Mappings;

public static class UserMapping
{
    public static User ToEntity(this RegisterUserRequest request, string encryptedPassword)
    {
        return new User(
            name: request.Name,
            email: request.Email,
            birthDate: request.BirthDate,
            cpf: request.CPF,
            enrollment: request.Enrollment,
            password: encryptedPassword
        );
    }

    public static User ToEntity(this UpdateUserRequest request, User existingUser)
    {
        existingUser.Name = request.Name;
        existingUser.BirthDate = request.BirthDate;
        existingUser.CPF = request.CPF;
        existingUser.Enrollment = request.Enrollment;
        return existingUser;
    }

    public static RegisterUserResponse ToRegisterUseResponse(this User user)
    {
        return new RegisterUserResponse(
            Name: user.Name!,
            Email: user.Email!
        );
    }

}

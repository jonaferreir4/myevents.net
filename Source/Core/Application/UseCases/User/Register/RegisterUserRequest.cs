
namespace Application.UseCases.User.Register;
    public sealed record RegisterUserRequest(
        string Name,
        string Email,
        DateOnly BirthDate,
        string CPF,
        int Enrollment,
        string Password
    );                      
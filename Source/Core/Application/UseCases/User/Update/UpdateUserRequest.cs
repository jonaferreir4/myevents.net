
namespace Application.UseCases.User.Update;
    public sealed record UpdateUserRequest(
        string Name,
        DateOnly BirthDate,
        string CPF,
        int Enrollment
    );                      

namespace Library.Http.Requests.User;
    public sealed record UpdateUserRequest(
        string Name,
        DateOnly BirthDate,
        string CPF,
        int Enrollment
    );                      
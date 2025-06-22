
namespace Library.Exceptions.Validation;
    public class EmailAlreadyRegisteredException(string email) :
        ValidationException($"Email '{email}' is already registered")
{}

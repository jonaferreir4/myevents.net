namespace Library.Exceptions;

public class ValidationException(string message):
    Exception(message){}

public class InvalidDateException(string message):
    ValidationException(message){}

public class EmailAlreadyRegisteredException : ValidationException
{
    public EmailAlreadyRegisteredException(string email)
        : base($"Email '{email}' is already registered") { }
}
namespace Library.Exceptions.Validation;
    public class InvalidDateException(string message):
        ValidationException(message){}
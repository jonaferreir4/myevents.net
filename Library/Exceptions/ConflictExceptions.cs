namespace Library.Exceptions;

public class ConflictException(string message):
    Exception(message){}

public class AlreadyRegisteredException(string entity, object identifier):
    ConflictException($"{entity} with identifier '{identifier}' is already registered")
{}

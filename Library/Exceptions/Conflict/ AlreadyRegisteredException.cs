namespace Library.Exceptions.Conflict;
    public class  AlreadyRegisteredException(string entity, object identifier):
    ConflictException($"{entity} with identifier '{identifier}' is already registered")
{}
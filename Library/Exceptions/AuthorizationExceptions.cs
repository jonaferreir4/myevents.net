namespace Library.Exceptions;
 public class UnauthorizedAccessException(string message):
    Exception(message){}

public class ForbiddenAccessException(string message): 
    Exception(message){}
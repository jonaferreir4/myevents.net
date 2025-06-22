namespace Library.Exceptions.NotFound;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(long id) :
        base("User", id){}

    public UserNotFoundException(string email) :
        base("User", email){}
}
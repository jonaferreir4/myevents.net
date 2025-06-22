namespace Library.Exceptions.NotFound;
public class EventNotFoundException(long id) :
    NotFoundException("Event", id){}

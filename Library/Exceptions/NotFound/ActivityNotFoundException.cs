namespace Library.Exceptions.NotFound;
    public class ActivityNotFoundException(long id) :
        NotFoundException("Activity", id) {}

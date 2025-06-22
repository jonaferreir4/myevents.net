namespace Library.Exceptions.NotFound;
    public class SponsorNotFoundException(long id):
     NotFoundException("Sponsor", id){ }

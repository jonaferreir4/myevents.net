namespace Library.Exceptions;

public class NotFoundException(string entityName, object key):
Exception($"Entity \"{entityName}\" ({key}) was not found."){}

public class ActivityNotFoundException(long id):
    NotFoundException("Activity", id){}

public class EventNotFoundException(long id):
    NotFoundException("Event", id){}

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(long id)
        : base("User", id) { }

    public UserNotFoundException(string email)
        : base("User", email) { }
}

public class AttendanceNotFoundException(long id):
    NotFoundException("Attendance", id){}

public class InscriptionNotFoundException(long id):
    NotFoundException("Inscription", id){}

public class SponsorNotFoundException(long id):
    NotFoundException("Sponsor", id){}

public class CertificateNotFoundException(long id):
    NotFoundException("Certificate", id){}

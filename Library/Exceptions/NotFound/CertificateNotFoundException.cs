namespace Library.Exceptions.NotFound;
    public class CertificateNotFoundException(long id):    
      NotFoundException("Attendance", id){ }

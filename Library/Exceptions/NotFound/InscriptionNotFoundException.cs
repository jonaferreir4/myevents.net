namespace Library.Exceptions.NotFound
{
    public class InscriptionNotFoundException(long id):
        NotFoundException("Inscription", id){ }
}
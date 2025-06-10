
namespace Application.UseCases.Inscription.Delete;
    public interface IDeleteInscriptionUC
    {
    public Task<DeleteInscriptionResponse> DeleteInscription(long id, long eventId);
}

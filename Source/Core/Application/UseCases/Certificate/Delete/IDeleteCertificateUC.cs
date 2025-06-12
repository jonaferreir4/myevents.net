
namespace Application.UseCases.Certificate.Delete;
    public interface IDeleteCertificateUC
    {
    public Task<DeleteCertificateResponse> DeleteCertificate(long id);
}

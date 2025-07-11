namespace Application.UseCases.Certificate.FindById;

public interface IFindCertificateByIdUC
{
    public Task<IEnumerable<Domain.Entities.Certificate>> FindCertificateByIdAsync(long id);
}

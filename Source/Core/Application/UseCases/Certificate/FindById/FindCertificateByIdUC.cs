using Domain.Contracts.Data.Repositories.Certificate;
using Library.Exceptions;
using Library.Utils.Authorization;

namespace Application.UseCases.Certificate.FindById;

public class FindCertificateByIdUC(
    ICertificateReadRepository readRepo,
    IHttpContextAccessor httpContextAccessor
) : IFindCertificateByIdUC
{
    public async Task<IEnumerable<Domain.Entities.Certificate>> FindCertificateByIdAsync(long id)
    {
        _ = AuthorizationHelper.GetAuthenticatedUserId(httpContextAccessor);

        var certificate = await readRepo.FindByIdAsync(id) ?? throw new NotFoundException("Certificate", id);
        return [certificate];
    }

}

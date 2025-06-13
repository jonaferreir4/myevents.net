using Domain.Contracts.Data.Repositories.Certificate;
using Domain.Contracts.Data.Services;
using Library.Utils.Authorization;

namespace Application.UseCases.Certificate.Delete;

public class DeleteCertificateUC(
    ICertificateWriteRepository writeRepo,
    ICertificateReadRepository readRepo,
    IHttpContextAccessor httpContextAccessor,
    IUnitOfWork unitOfWork) : IDeleteCertificateUC
{
    public async Task<DeleteCertificateResponse> DeleteCertificate(long id)
    {
        var userId = AuthorizationHelper.GetAuthenticatedUserId(httpContextAccessor);
       
        var certificate = await readRepo.FindByIdWithRelationsAsync(id)
            ?? throw new KeyNotFoundException($"Certificate with ID {id} not found.");

        if (certificate.UserId != userId)
        {
            throw new UnauthorizedAccessException("You are not authorized to delete this Certificate.");
        }
        
        await writeRepo.DeleteAsync(id);
        await unitOfWork.CommitAsync();
        
        return new DeleteCertificateResponse(id);
    }
}
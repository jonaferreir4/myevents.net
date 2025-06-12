using Domain.Contracts.Data.Repositories.Attendance;
using Domain.Contracts.Data.Repositories.Certificate;
using Domain.Contracts.Data.Services;
using Library.Utils.Authorization;

namespace Application.UseCases.Certificate.Delete;

public class DeleteCertificateUC(
    ICertificateWriteRepository writeRepo,
    ICertificateReadRepository readRepo,
    IAttendanceReadRepository attendanceReadRepo,
    IHttpContextAccessor httpContextAccessor,
    IUnitOfWork unitOfWork) : IDeleteCertificateUC
{
    public async Task<DeleteCertificateResponse> DeleteCertificate(long id)
    {
        var userId = AuthorizationHelper.GetAuthenticatedUserId(httpContextAccessor);
       
        var certificate = await readRepo.FindByIdWithRelationsAsync(id)
            ?? throw new KeyNotFoundException($"Certificate with ID {id} not found.");

        // Verifica se o usuário é o dono do certificado
        if (certificate.UserId != userId)
        {
            throw new UnauthorizedAccessException("You are not authorized to delete this Certificate.");
        }

        // Verifica se o usuário realmente participou da atividade
        var attendance = await attendanceReadRepo.FindByUserIdAndActivityIdAsync(userId, certificate.ActivityId);
       
        if (attendance == null || !attendance.IsPresent)
        {
            throw new InvalidOperationException("Cannot delete certificate for unattended activity");
        }
        
        await writeRepo.DeleteAsync(id);
        await unitOfWork.CommitAsync();
        
        return new DeleteCertificateResponse(id);
    }
}
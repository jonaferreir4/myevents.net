using Application.UseCases.Certificate.Register;
using Domain.Contracts.Data.Repositories.Attendance;
using Domain.Contracts.Data.Services;
using Library.Utils.Authorization;


namespace Application.UseCases.Certificate.Register;
public class RegisterCertificateUC(
    IAttendanceReadRepository attendanceReadRepo,
    ICertificateGeneratorService certificateGeneratorService,
    IHttpContextAccessor httpContextAccessor
) : IRegisterCertificateUC
{
    public async Task<RegisterCertificateResponse> RegisterCertificate(long activityId)
    {
        var userId = AuthorizationHelper.GetAuthenticatedUserId(httpContextAccessor);

        var attendance = await attendanceReadRepo.FindByUserIdAndActivityIdAsync(userId, activityId);
        if (!attendance.IsPresent)
        {
            throw new InvalidOperationException("The user has not confirmed attendance");
        }

        await certificateGeneratorService.GenerateCertificateForUser((int)activityId, userId);

        return new RegisterCertificateResponse(attendance.Id, userId, activityId);
    }
}

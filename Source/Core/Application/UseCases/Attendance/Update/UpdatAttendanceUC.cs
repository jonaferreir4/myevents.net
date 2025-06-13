using Application.Services;
using Domain.Contracts.Data.Repositories.Attendance;
using Domain.Contracts.Data.Services;
using Library.Utils.Authorization;

namespace Application.UseCases.Attendance.Update;

public class UpdateAttendanceUC(
    IAttendanceWriteRepository  writeRepo,
    IAttendanceReadRepository readRepo,
    IUnitOfWork unitOfWork,
    IHttpContextAccessor httpContextAccessor,
    CertificateGeneratorService certificateGeneratorService

) : IUpdateAttendanceUC
{


    public async Task<UpdateAttendanceResponse> UpdateAttendance(long id)
    {
        var attendance = await readRepo.FindByIdAsync(id)
            ?? throw new KeyNotFoundException($"Attendance with ID {id} not found.");

        var participantId = AuthorizationHelper.GetAuthenticatedUserId(httpContextAccessor);

        if (participantId == 0 || participantId != attendance.UserId)
        {
              throw new UnauthorizedAccessException($"User {participantId} is not authorized to update this attendance.");

        }

        attendance.ConfirmPresence();

        await writeRepo.UpdateAsync(attendance);
        await unitOfWork.CommitAsync();
        
        await certificateGeneratorService.GenerateCertificateForUser(
       attendance.ActivityId, participantId
       );

        return new UpdateAttendanceResponse(attendance.Id);
       

    }
}
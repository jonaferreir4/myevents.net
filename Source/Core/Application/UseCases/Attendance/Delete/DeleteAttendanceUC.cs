using Application.Mappings;
using Application.Services;
using Domain.Contracts.Data.Repositories.Attendance;
using Domain.Contracts.Data.Repositories.Event;
using Domain.Contracts.Data.Services;
using Library.Utils.Authorization;

namespace Application.UseCases.Attendance.Delete;

public class DeleteAttendanceUC(
    IAttendanceWriteRepository writeRepo,
    IAttendanceReadRepository readRepo,
    IHttpContextAccessor httpContextAccessor,
    IUnitOfWork unitOfWork
) : IDeleteAttendanceUC
{
    public async Task<DeleteAttendanceResponse> DeleteAttendance(long id, long activityId)
    {
        var userId = AuthorizationHelper.GetAuthenticatedUserId(httpContextAccessor);
       
        var Attendance = await readRepo.FindByIdAsync(id)
            ?? throw new KeyNotFoundException($"Attendance with ID {id} not found.");

        if (Attendance.ActivityId != activityId)
        {
            throw new UnauthorizedAccessException($"Attendance with ID {id} does not belong to activity {activityId}.");
        }

        if (Attendance.UserId != userId)
        {
            throw new UnauthorizedAccessException("You are not authorized to delete this Attendance.");
        }
        
        await writeRepo.DeleteAsync(id); // Corrigido: era Id (inexistente), agora é id
        await unitOfWork.CommitAsync();
        
        return new DeleteAttendanceResponse(id); // Corrigido aqui também
    }
}

using Domain.Contracts.Data.Repositories.Attendance;
using Domain.Contracts.Data.Services;
using Library.Utils.Authorization;
using Domain.Contracts.Data.Repositories.User;
using Domain.Contracts.Data.Repositories.Activity;
using Domain.Contracts.Data.Repositories.Inscription;
using Domain.Contracts.Data.Repositories.Event;

namespace Application.UseCases.Attendance.Register;

public class RegisterAttendanceUC(
    IAttendanceWriteRepository  writeRepo,
    IAttendanceReadRepository readRepo,
    IEventReadRepository eventReadRepository,
    IActivityReadRepository readAtvRepo,
    IUserReadRepository readUserRepo,
    IInscriptionReadRepository readIncriptionRepo,

    IUnitOfWork unitOfWork,
    IHttpContextAccessor httpContextAccessor

) : IRegisterAttendanceUC
{


    public async Task<RegisterAttendanceResponse> RegisterAttendance(long activityId)
    {
       var userId = AuthorizationHelper.GetAuthenticatedUserId(httpContextAccessor);

       var activity = await readAtvRepo.FindByIdAsync(activityId)
        ?? throw new KeyNotFoundException($"Activity with ID {activityId} not found.");

        _ = await readAtvRepo.FindByIdAsync(activityId)
            ?? throw new KeyNotFoundException($"Event with ID {activityId} not found.");

        _ = await readUserRepo.FindByIdAsync(userId)
            ?? throw new KeyNotFoundException($"User with ID {userId} not found.");


        var eventId = activity.EventId;

        _ = await readIncriptionRepo.FindByUserIdAndEventIdAsync(userId, eventId) ?? throw new InvalidOperationException($"User {userId} is not inscribed in the event {eventId} related to this activity.");

        var AttendanceExisting = await readRepo.FindByUserIdAndActivityIdAsync(userId, activityId);
        if (AttendanceExisting != null)
        {
            throw new InvalidOperationException($"User {userId} is already registered for activity {activityId}.");
        }

        var attendance = new Domain.Entities.Attendance(userId, activityId, false);
           
        await writeRepo.CreateAsync(attendance);
        await unitOfWork.CommitAsync();
        return new RegisterAttendanceResponse(attendance.Id, userId, activityId);
    }
}
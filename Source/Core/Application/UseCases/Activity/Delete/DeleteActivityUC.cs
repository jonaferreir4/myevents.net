

using Application.Mappings;
using Application.Services;
using Domain.Contracts.Data.Repositories.Activity;
using Domain.Contracts.Data.Repositories.Event;
using Domain.Contracts.Data.Services;
using Library.Utils.Authorization;

namespace Application.UseCases.Activity.Delete;

public class DeleteActivityUC(
    IActivityWriteRepository  writeRepo,
    IActivityReadRepository readRepo,
    IEventReadRepository readEventRepo,
    IHttpContextAccessor httpContextAccessor,
    IUnitOfWork unitOfWork

) : IDeleteActivityUC
{


    public async Task<DeleteActivityResponse> DeleteActivity(long eventId, long Id)
    {
        var activity = await readRepo.FindByIdAsync(Id)
            ?? throw new KeyNotFoundException($"Activity with ID {Id} not found.");

        if (activity.EventId != eventId)
        {
            throw new UnauthorizedAccessException($"Activity with ID {Id} does not belong to event {eventId}.");
        }

        var organizerId = AuthorizationHelper.GetAuthenticatedUserId(httpContextAccessor);

        var eventExisting = await readEventRepo.FindByIdAsync(eventId)
            ?? throw new KeyNotFoundException($"Event with ID {eventId} not found.");

        if (eventExisting.OrganizerId != organizerId)
            throw new UnauthorizedAccessException("You are not authorized to delete this activity.");
        
        await writeRepo.DeleteAsync(Id);
        await unitOfWork.CommitAsync();
        
        return new DeleteActivityResponse(Id);

    }
}
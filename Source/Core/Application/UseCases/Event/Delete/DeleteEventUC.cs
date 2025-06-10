using Domain.Contracts.Data.Repositories.Event;
using Domain.Contracts.Data.Services;
using Library.Utils.Authorization;

namespace Application.UseCases.Event.Delete;

public class DeleteEventUC(
    IEventWriteRepository  writeRepo,
    IEventReadRepository readRepo,
    IUnitOfWork unitOfWork,
    IHttpContextAccessor httpContextAccessor
) : IDeleteEventUC
{


    public async Task<DeleteEventResponse> DeleteEvent(long Id)
    {
        var organizerId = AuthorizationHelper.GetAuthenticatedUserId(httpContextAccessor);
        
        var eventToDelete = await readRepo.FindByIdAsync(Id);
        Console.WriteLine(eventToDelete);
        if (eventToDelete == null)
            throw new KeyNotFoundException("Event not found.");

        if (eventToDelete.OrganizerId != organizerId)
            throw new UnauthorizedAccessException("You are not authorized to delete this event.");
            
        await writeRepo.DeleteAsync(Id);
        await unitOfWork.CommitAsync();
        
        return new DeleteEventResponse(Id);

    }
}
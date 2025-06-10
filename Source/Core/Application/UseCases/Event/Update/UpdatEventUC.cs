

using Application.Mappings;
using Domain.Contracts.Data.Repositories.Event;
using Domain.Contracts.Data.Services;
using Library.Utils.Authorization;

namespace Application.UseCases.Event.Update;

public class UpdateEventUC(
    IEventWriteRepository  writeRepo,
    IEventReadRepository readRepo,
    IUnitOfWork unitOfWork,
    IHttpContextAccessor httpContextAccessor

) : IUpdateEventUC
{


    public async Task<UpdateEventResponse> UpdateEvent(long id, UpdateEventRequest request)
    {
        var eventToUpdate = await readRepo.FindByIdAsync(id)
            ?? throw new KeyNotFoundException($"Event with ID {id} not found.");

        var organizerId = AuthorizationHelper.GetAuthenticatedUserId(httpContextAccessor);

        if (eventToUpdate.OrganizerId != organizerId)
            throw new UnauthorizedAccessException("You are not authorized to update this event.");

        var mapEvent = request.ToEntity(eventToUpdate);

        await writeRepo.UpdateAsync(mapEvent);
        await unitOfWork.CommitAsync();

        return new UpdateEventResponse(request.Name);
       

    }
}
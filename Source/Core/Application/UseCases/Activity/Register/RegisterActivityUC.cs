using Application.Mappings;
using Domain.Contracts.Data.Repositories.Activity;
using Domain.Contracts.Data.Repositories.Event;
using Domain.Contracts.Data.Services;
using Library.Utils.Authorization;

namespace Application.UseCases.Activity.Register;

public class RegisterActivityUC(
    IActivityWriteRepository  writeRepo,
    IEventReadRepository readEventRepo,
    IUnitOfWork unitOfWork,
    IHttpContextAccessor httpContextAccessor

) : IRegisterActivityUC
{


    public async Task<RegisterActivityResponse> RegisterActivity(long eventId, RegisterActivityRequest request)
    {

        var eventExisting = await readEventRepo.FindByIdAsync(eventId)
            ?? throw new KeyNotFoundException($"Event with ID {eventId} not found.");

       var organizerId = AuthorizationHelper.GetAuthenticatedUserId(httpContextAccessor);

        if (eventExisting.OrganizerId != organizerId)
            throw new UnauthorizedAccessException("You are not authorized create a activity.");
       
       
        var Activity = request.ToEntity(eventId);
        Activity.EventId = eventId;
        await writeRepo.CreateAsync(Activity);
        await unitOfWork.CommitAsync();
        return Activity.ToResponse();
    }
}
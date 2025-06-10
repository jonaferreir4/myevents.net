using Application.Mappings;
using Domain.Contracts.Data.Repositories.Event;
using Domain.Contracts.Data.Repositories.User;
using Domain.Contracts.Data.Services;
using Library.Utils.Authorization;

namespace Application.UseCases.Event.Register;

public class RegisterEventUC(
    IEventWriteRepository  writeRepo,
     IHttpContextAccessor httpContextAccessor,
    IUnitOfWork unitOfWork

) : IRegisterEventUC
{


    public async Task<RegisterEventResponse> RegisterEvent(RegisterEventRequest request)
    {


        if (request == null)
            throw new ArgumentNullException(nameof(request));
        
        var organizerId = AuthorizationHelper.GetAuthenticatedUserId(httpContextAccessor);

      
        if (organizerId <= 0)
            throw new Exception("Organizer not found");

        if (request.StartDate > request.EndDate)
            throw new Exception("End date must be after start date");

        if (request.StartDate == request.EndDate && request.StartTime >= request.EndTime)
            throw new Exception("End time must be after start time when dates are equal");

        var @event = request.ToEntity(organizerId);
        @event.OrganizerId = organizerId;
        await writeRepo.CreateAsync(@event);
        await unitOfWork.CommitAsync();

        return @event.ToResponse();

    }
}
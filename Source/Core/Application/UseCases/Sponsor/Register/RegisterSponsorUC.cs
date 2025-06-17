using Application.Mappings;
using Domain.Contracts.Data.Repositories.Event;
using Domain.Contracts.Data.Repositories.Sponsor;
using Domain.Contracts.Data.Repositories.User;
using Domain.Contracts.Data.Services;
using Library.Utils.Authorization;

namespace Application.UseCases.Sponsor.Register;

public class RegisterSponsorUC(
    ISponsorWriteRepository  writeRepo,
    IEventReadRepository  eventReadRepo,
     IHttpContextAccessor httpContextAccessor,
    IUnitOfWork unitOfWork

) : IRegisterSponsorUC
{


    public async Task<RegisterSponsorResponse> RegisterSponsor(RegisterSponsorRequest request)
    {


        ArgumentNullException.ThrowIfNull(request);

        var organizerId = AuthorizationHelper.GetAuthenticatedUserId(httpContextAccessor);
        var @event = await eventReadRepo.FindByIdAsync(request.EventId) ??
            throw new KeyNotFoundException("Event not Found");

        if (organizerId <= 0)
            throw new Exception("Organizer not found");

        if (@event.OrganizerId != organizerId)
        {
             throw new UnauthorizedAccessException("You are not authorized to delete this Sponsor.");
        }

        // Map request to Sponsor entity
        var sponsor = request.ToEntity();
        await writeRepo.CreateAsync(sponsor);
        await unitOfWork.CommitAsync();

        return sponsor.ToResponse();

    }
}
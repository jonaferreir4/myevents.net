using Domain.Contracts.Data.Repositories.Event;
using Domain.Contracts.Data.Repositories.Sponsor;
using Domain.Contracts.Data.Services;
using Library.Utils.Authorization;

namespace Application.UseCases.Sponsor.Delete;

public class DeleteSponsorUC(
    ISponsorWriteRepository  writeRepo,
    ISponsorReadRepository readRepo,
    IEventReadRepository eventReadRepo,
    IUnitOfWork unitOfWork,
    IHttpContextAccessor httpContextAccessor
) : IDeleteSponsorUC
{


    public async Task<DeleteSponsorResponse> DeleteSponsor(long Id)
    {
        var organizerId = AuthorizationHelper.GetAuthenticatedUserId(httpContextAccessor);
        var sponsor = await readRepo.FindByIdAsync(Id) ??
            throw new KeyNotFoundException("Sponsor not found.");
        var @event = await eventReadRepo.FindByIdAsync(sponsor.EventId) ??
            throw new KeyNotFoundException("Event not found.");

        if (@event.OrganizerId != organizerId)
            throw new UnauthorizedAccessException("You are not authorized to delete this Sponsor.");
            
        await writeRepo.DeleteAsync(Id);
        await unitOfWork.CommitAsync();
        
        return new DeleteSponsorResponse(Id);

    }
}
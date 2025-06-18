

using Application.Mappings;
using Domain.Contracts.Data.Repositories.Event;
using Domain.Contracts.Data.Repositories.Sponsor;
using Domain.Contracts.Data.Services;
using Library.Http.Requests.Sponsor;
using Library.Http.Responses.Sponsor;
using Library.Utils.Authorization;

namespace Application.UseCases.Sponsor.Update;

public class UpdateSponsorUC(
    ISponsorWriteRepository  writeRepo,
    ISponsorReadRepository readRepo,
    IEventReadRepository eventReadRepo,
    IUnitOfWork unitOfWork,
    IHttpContextAccessor httpContextAccessor

) : IUpdateSponsorUC
{


    public async Task<UpdateSponsorResponse> UpdateSponsor(long id, UpdateSponsorRequest request)
    {
        var organizerId = AuthorizationHelper.GetAuthenticatedUserId(httpContextAccessor);

        var SponsorToUpdate = await readRepo.FindByIdAsync(id)
            ?? throw new KeyNotFoundException($"Sponsor with ID {id} not found.");

        var @event = await eventReadRepo.FindByIdAsync(SponsorToUpdate.EventId) ??
            throw new KeyNotFoundException("Event not Found.") ;


        if (@event.OrganizerId != organizerId)
            throw new UnauthorizedAccessException("You are not authorized to update this Sponsor.");

        var mapSponsor = request.ToEntity();

        await writeRepo.UpdateAsync(mapSponsor);
        await unitOfWork.CommitAsync();

        return mapSponsor.ToUpdateResponse();
       

    }
}
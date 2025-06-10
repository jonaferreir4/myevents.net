using Application.Mappings;
using Domain.Contracts.Data.Repositories.Activity;
using Domain.Contracts.Data.Services; // Add this if NotFoundException is in System or for Exception base class

namespace Application.UseCases.Activity.Update;

public class UpdateActivityUC(
    IActivityWriteRepository  writeRepo,
    IActivityReadRepository readRepo,
    IUnitOfWork unitOfWork


) : IUpdateActivityUC
{


    public async Task<UpdateActivityResponse> UpdateActivity(long eventId, long id, UpdateActivityRequest request)
    {
        var Activity = await readRepo.FindByIdAsync(id)
            ?? throw new Exception($"Activity not found with ID {id}.");
               
        if (Activity.EventId != eventId)
    {
        throw new Exception($"Activity does not belong to event {eventId}.");
    }

        var mapActivity = request.ToEntity(Activity);
        await writeRepo.UpdateAsync(mapActivity);
        await unitOfWork.CommitAsync();

        return new UpdateActivityResponse(request.Name, request.MaxParticipants, request.CertificationHours);
       

    }
}
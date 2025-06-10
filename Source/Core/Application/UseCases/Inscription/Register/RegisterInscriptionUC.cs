using Application.Mappings;
using Domain.Contracts.Data.Repositories.Inscription;
using Domain.Contracts.Data.Repositories.Event;
using Domain.Contracts.Data.Services;
using Library.Utils.Authorization;
using Domain.Contracts.Data.Repositories.User;

namespace Application.UseCases.Inscription.Register;

public class RegisterInscriptionUC(
    IInscriptionWriteRepository  writeRepo,
    IInscriptionReadRepository readRepo,
    IEventReadRepository readEventRepo,
    IUserReadRepository readUserRepo,
    IUnitOfWork unitOfWork,
    IHttpContextAccessor httpContextAccessor

) : IRegisterInscriptionUC
{


    public async Task<RegisterInscriptionResponse> RegisterInscription(long eventId)
    {
       var userId = AuthorizationHelper.GetAuthenticatedUserId(httpContextAccessor);

        _ = await readEventRepo.FindByIdAsync(eventId)
            ?? throw new KeyNotFoundException($"Event with ID {eventId} not found.");

        _ = await readUserRepo.FindByIdAsync(userId)
            ?? throw new KeyNotFoundException($"User with ID {userId} not found.");



        var inscriptionExisting = await readRepo.FindByUserIdAndEventIdAsync(userId, eventId);

        if (inscriptionExisting != null)
        {
            throw new InvalidOperationException($"User {userId} is already registered for event {eventId}.");
        }

        var inscription = new Domain.Entities.Inscription(userId, eventId);
           
        await writeRepo.CreateAsync(inscription);
        await unitOfWork.CommitAsync();
        return new RegisterInscriptionResponse(inscription.Id, userId, eventId);
    }
}
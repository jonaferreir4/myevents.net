using Application.Mappings;
using Application.Services;
using Domain.Contracts.Data.Repositories.Inscription;
using Domain.Contracts.Data.Repositories.Event;
using Domain.Contracts.Data.Services;
using Library.Utils.Authorization;

namespace Application.UseCases.Inscription.Delete;

public class DeleteInscriptionUC(
    IInscriptionWriteRepository writeRepo,
    IInscriptionReadRepository readRepo,
    IHttpContextAccessor httpContextAccessor,
    IUnitOfWork unitOfWork
) : IDeleteInscriptionUC
{
    public async Task<DeleteInscriptionResponse> DeleteInscription(long id, long eventId)
    {
        var userId = AuthorizationHelper.GetAuthenticatedUserId(httpContextAccessor);
       
        var inscription = await readRepo.FindByIdAsync(id)
            ?? throw new KeyNotFoundException($"Inscription with ID {id} not found.");

        if (inscription.EventId != eventId)
        {
            throw new UnauthorizedAccessException($"Inscription with ID {id} does not belong to event {eventId}.");
        }

        if (inscription.UserId != userId)
        {
            throw new UnauthorizedAccessException("You are not authorized to delete this Inscription.");
        }
        
        await writeRepo.DeleteAsync(id); // Corrigido: era Id (inexistente), agora é id
        await unitOfWork.CommitAsync();
        
        return new DeleteInscriptionResponse(id); // Corrigido aqui também
    }
}

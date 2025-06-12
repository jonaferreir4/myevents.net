using Domain.Contracts.Data.Repositories.Certificate;
using Domain.Contracts.Data.Services;
using Library.Utils.Authorization;
using Domain.Contracts.Data.Repositories.User;
using Domain.Contracts.Data.Repositories.Activity;
using Domain.Contracts.Data.Repositories.Inscription;
using Domain.Contracts.Data.Repositories.Event;

namespace Application.UseCases.Certificate.Register;

public class RegisterCertificateUC(
    ICertificateWriteRepository  writeRepo,
    ICertificateReadRepository readRepo,
    IEventReadRepository eventReadRepository,
    IActivityReadRepository readAtvRepo,
    IUserReadRepository readUserRepo,
    IInscriptionReadRepository readIncriptionRepo,

    IUnitOfWork unitOfWork,
    IHttpContextAccessor httpContextAccessor

) : IRegisterCertificateUC
{


    public async Task<RegisterCertificateResponse> RegisterCertificate(long activityId)
    {
       var userId = AuthorizationHelper.GetAuthenticatedUserId(httpContextAccessor);

       var activity = await readAtvRepo.FindByIdAsync(activityId)
        ?? throw new KeyNotFoundException($"Activity with ID {activityId} not found.");

        
        _ = await readUserRepo.FindByIdAsync(userId)
            ?? throw new KeyNotFoundException($"User with ID {userId} not found.");


        var eventId = activity.EventId;

        _ = await readIncriptionRepo.FindByUserIdAndEventIdAsync(userId, eventId) ?? throw new InvalidOperationException($"User {userId} is not inscribed in the event {eventId} related to this activity.");

        var CertificateExisting = await readRepo.FindByUserIdAndActivityIdAsync(userId, activityId);
        if (CertificateExisting != null)
        {
            throw new InvalidOperationException($"User {userId} is already registered for activity {activityId}.");
        }

        var Certificate = new Domain.Entities.Certificate();
           
        await writeRepo.CreateAsync(Certificate);
        await unitOfWork.CommitAsync();
        return new RegisterCertificateResponse(Certificate.Id, userId, activityId);
    }
}
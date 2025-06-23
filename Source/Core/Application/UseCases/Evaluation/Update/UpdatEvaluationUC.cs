using Application.Mappings;
using Application.Services;
using Domain.Contracts.Data.Repositories.Evaluation;
using Domain.Contracts.Data.Services;
using Library.Http.Requests.Evaluation;
using Library.Http.Responses.Evaluation;
using Library.Utils.Authorization;

namespace Application.UseCases.Evaluation.Update;

public class UpdateEvaluationUC(
    IEvaluationWriteRepository  writeRepo,
    IEvaluationReadRepository readRepo,
    IUnitOfWork unitOfWork,
    IHttpContextAccessor httpContextAccessor,
    CertificateGeneratorService certificateGeneratorService

) : IUpdateEvaluationUC
{


    public async Task<UpdateEvaluationResponse> UpdateEvaluation(UpdateEvaluationRequest request, long id)
    {
        var Evaluation = await readRepo.FindByIdAsync(id)
            ?? throw new KeyNotFoundException($"Evaluation with ID {id} not found.");

        var participantId = AuthorizationHelper.GetAuthenticatedUserId(httpContextAccessor);

        if (participantId == 0 || participantId != Evaluation.UserId)
        {
              throw new UnauthorizedAccessException($"User {participantId} is not authorized to update this Evaluation.");

        }


        request.ToEntity(Evaluation);

        await writeRepo.UpdateAsync(Evaluation);
        await unitOfWork.CommitAsync();
        
        await certificateGeneratorService.GenerateCertificateForUser(
       Evaluation.ActivityId, participantId
       );

        return Evaluation.ToUpdateResponse();
       

    }
}
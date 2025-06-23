using Domain.Contracts.Data.Repositories.Evaluation;
using Domain.Contracts.Data.Services;
using Library.Utils.Authorization;
using Domain.Contracts.Data.Repositories.User;
using Domain.Contracts.Data.Repositories.Activity;
using Library.Http.Responses.Evaluation;
using Library.Http.Requests.Evaluation;
using Application.Mappings;

namespace Application.UseCases.Evaluation.Register;

public class RegisterEvaluationUC(
    IEvaluationWriteRepository  writeRepo,
    IActivityReadRepository readAtvRepo,
    IUserReadRepository readUserRepo,

    IUnitOfWork unitOfWork,
    IHttpContextAccessor httpContextAccessor

) : IRegisterEvaluationUC
{


    public async Task<RegisterEvaluationResponse> RegisterEvaluation(RegisterEvaluationRequest request)
    {
       var userId = AuthorizationHelper.GetAuthenticatedUserId(httpContextAccessor);

       var activity = await readAtvRepo.FindByIdAsync(request.ActivityId)
        ?? throw new KeyNotFoundException($"Activity with ID {request.ActivityId} not found.");

        
        _ = await readUserRepo.FindByIdAsync(userId)
            ?? throw new KeyNotFoundException($"User with ID {userId} not found.");


        var Evaluation = request.ToEntity(userId);
           
        await writeRepo.CreateAsync(Evaluation);
        await unitOfWork.CommitAsync();
        return  Evaluation.ToResponse();
    }
}
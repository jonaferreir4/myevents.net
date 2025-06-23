using Domain.Contracts.Data.Repositories.Evaluation;
using Domain.Contracts.Data.Services;
using Library.Http.Responses.Evaluation;
using Library.Utils.Authorization;

namespace Application.UseCases.Evaluation.Delete;

public class DeleteEvaluationUC(
    IEvaluationWriteRepository writeRepo,
    IEvaluationReadRepository readRepo,
    IHttpContextAccessor httpContextAccessor,
    IUnitOfWork unitOfWork
) : IDeleteEvaluationUC
{
    public async Task<DeleteEvaluationResponse> DeleteEvaluation(long id)
    {
        var userId = AuthorizationHelper.GetAuthenticatedUserId(httpContextAccessor);
       
        var Evaluation = await readRepo.FindByIdAsync(id)
            ?? throw new KeyNotFoundException($"Evaluation with ID {id} not found.");

        if (Evaluation.UserId != userId)
        {
            throw new UnauthorizedAccessException("You are not authorized to delete this Evaluation.");
        }
        
        await writeRepo.DeleteAsync(id);
        await unitOfWork.CommitAsync();
        
        return new DeleteEvaluationResponse(id);
    }
}

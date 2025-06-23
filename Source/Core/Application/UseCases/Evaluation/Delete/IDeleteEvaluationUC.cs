
using Library.Http.Responses.Evaluation;

namespace Application.UseCases.Evaluation.Delete;
    public interface IDeleteEvaluationUC
    {
    public Task<DeleteEvaluationResponse> DeleteEvaluation(long id);
}

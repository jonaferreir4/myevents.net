
using Library.Http.Requests.Evaluation;
using Library.Http.Responses.Evaluation;

namespace Application.UseCases.Evaluation.Update;
    public interface IUpdateEvaluationUC
    {
        public Task<UpdateEvaluationResponse> UpdateEvaluation(UpdateEvaluationRequest request, long Id);
    }

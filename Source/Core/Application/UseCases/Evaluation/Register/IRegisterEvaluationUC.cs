
using Library.Http.Requests.Evaluation;
using Library.Http.Responses.Evaluation;

namespace Application.UseCases.Evaluation.Register;
    public interface IRegisterEvaluationUC
    {
        public Task<RegisterEvaluationResponse> RegisterEvaluation(RegisterEvaluationRequest request);
    }

using Domain.Entities;
using Library.Http.Requests.Evaluation;
using Library.Http.Responses.Evaluation;

namespace Application.Mappings;

public static class EvaluationMapping
{
    public static Evaluation ToEntity(this RegisterEvaluationRequest request, long UserId)
    {
        return new Evaluation(
            rating: request.Rating,
            comment: request.Comment,
            activityId: request.ActivityId,
            userId: UserId
        );
    }

    public static Evaluation ToEntity(this UpdateEvaluationRequest request, Evaluation existingEvaluation)
    {
        existingEvaluation.Rating = request.Rating;
        existingEvaluation.Comment = request.Comment;

        return existingEvaluation;
    }


    public static RegisterEvaluationResponse ToResponse(this Evaluation evaluation)
    {
        return new RegisterEvaluationResponse(evaluation.Id, evaluation.Rating, evaluation.Comment);
    }

    public static UpdateEvaluationResponse ToUpdateResponse(this Evaluation evaluation)
{
    return new UpdateEvaluationResponse(evaluation.Id, evaluation.Rating, evaluation.Comment);
}
}

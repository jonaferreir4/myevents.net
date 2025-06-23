namespace Library.Http.Requests.Evaluation;
    public sealed record RegisterEvaluationRequest(long ActivityId, int Rating, string Comment);
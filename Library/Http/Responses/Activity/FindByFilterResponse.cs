namespace Library.Http.Responses.Activity;
    public sealed record FindByFilterResponse
    (
         string Name,
         string Theme,
         string Type,
         string Description,
         DateOnly StartDate,
         DateOnly EndDate,
         TimeOnly StartTime,
         TimeOnly EndTime,
         int MaxParticipants,
         TimeSpan CertificationHours
    );
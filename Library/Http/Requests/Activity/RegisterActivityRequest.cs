
namespace Library.Http.Requests.Activity;
    public sealed record RegisterActivityRequest(
        string Name,
        string  Theme,
        string Type,
        string Description,
        DateOnly StartDate,
        DateOnly EndDate,
        TimeOnly StartTime,
        TimeOnly EndTime,
        int MaxParticipants,
        TimeSpan CertificationHours,
        long SpeakerId
    );                      

namespace Application.UseCases.Activity.Register;
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
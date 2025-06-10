
namespace Application.UseCases.Activity.Update;
    public sealed record UpdateActivityRequest(
        string Name,
        string Theme,
        string Type,
        string Description,
        DateOnly StartDate,
        DateOnly EndDate,
        TimeOnly StartTime,
        TimeOnly EndTime,
        int MaxParticipants,
        TimeOnly CertificationHours
    );                      
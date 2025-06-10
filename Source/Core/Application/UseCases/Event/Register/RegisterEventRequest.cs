
namespace Application.UseCases.Event.Register;
    public sealed record RegisterEventRequest(
        string Name,
        string Theme,
        string Description,
        DateOnly StartDate,
        DateOnly EndDate,
        TimeOnly StartTime,
        TimeOnly EndTime,
        string Location,
        string Modality
    );                      
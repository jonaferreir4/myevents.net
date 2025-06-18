
namespace Library.Http.Requests.Event;
    public sealed record UpdateEventRequest(
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
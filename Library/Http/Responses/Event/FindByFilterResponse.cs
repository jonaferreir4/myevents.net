namespace Library.Http.Responses.Event;

public sealed record FindByFilterResponse
(
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
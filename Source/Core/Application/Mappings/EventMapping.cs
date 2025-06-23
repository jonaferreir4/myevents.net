
using Domain.Entities;
using Library.Http.Requests.Event;
using Library.Http.Responses.Event;

namespace Application.Mappings;

public static class EventMapping
{
    public static Event ToEntity(this RegisterEventRequest request, long organizerId)
    {
        return new Event(
          name: request.Name,
          theme: request.Theme,
          description: request.Description,
          startDate: request.StartDate,
          endDate: request.EndDate,
          startTime: request.StartTime,
          endTime: request.EndTime,
          location: request.Location,
          modality: request.Modality,
          organizerId: organizerId
        );
    }

    public static Event ToEntity(this UpdateEventRequest request, Event existingEvent)
    {
        existingEvent.Name = request.Name;
        existingEvent.Theme = request.Theme;
        existingEvent.Description = request.Description;
        existingEvent.StartDate = request.StartDate;
        existingEvent.EndDate = request.EndDate;
        existingEvent.StartTime = request.StartTime;
        existingEvent.EndTime = request.EndTime;
        existingEvent.Location = request.Location;
        existingEvent.Modality = request.Modality;

        return existingEvent; // Retorna a mesma instância atualizada
    }

    public static FindByFilterResponse ToFindResponse(this Event @event)
    {
        return new FindByFilterResponse(
            @event.Name,
            @event.Theme,
            @event.Description,
            @event.StartDate,
            @event.EndDate,
            @event.StartTime,
            @event.EndTime,
            @event.Location,
            @event.Modality
        );
    }

    public static RegisterEventResponse ToResponse(this Event @event)
    {
        return new RegisterEventResponse(
            @event.Id,
            @event.Name,
            @event.Description
        );
    }
}

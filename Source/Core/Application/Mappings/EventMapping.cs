
using Application.UseCases.Event.Register;
using Application.UseCases.Event.Update;
using Domain.Entities;

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
            organizerId: existingEvent.OrganizerId
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

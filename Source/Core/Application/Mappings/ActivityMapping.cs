
using Application.UseCases.Activity.Register;
using Application.UseCases.Activity.Update;
using Domain.Entities;

namespace Application.Mappings;

public static class ActivityMapping
{
    public static Activity ToEntity(this RegisterActivityRequest request, long eventId)
    {
        return new Activity(
          name: request.Name,
          theme: request.Theme,
          type: request.Type,
          description: request.Description,
          startDate: request.StartDate,
          endDate: request.EndDate,
          startTime: request.StartTime,
          endTime: request.EndTime,
          maxParticipants: request.MaxParticipants,
          certificationHours: request.CertificationHours,
          eventId: eventId,
          speakerId: request.SpeakerId
        );
    }
    
    public static Activity ToEntity(this UpdateActivityRequest request, Activity existingActivity)
    {
        return new Activity(
          name: request.Name,
          theme: request.Theme,
          type: request.Type,
          description: request.Description,
          startDate: request.StartDate,
          endDate: request.EndDate,
          startTime: request.StartTime,
          endTime: request.EndTime,
          maxParticipants: request.MaxParticipants,
          certificationHours: request.CertificationHours,
          speakerId: existingActivity.SpeakerId,
          eventId: existingActivity.EventId

         
        );
    }
      

    public static RegisterActivityResponse ToResponse(this Activity Activity)
    {
        return new RegisterActivityResponse(
            Activity.Name,
            Activity.Theme
        );
    }
    }

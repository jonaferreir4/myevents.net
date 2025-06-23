using Application.UseCases.Activity.Update;
using Domain.Entities;
using Library.Http.Requests.Activity;
using Library.Http.Responses.Activity;

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
        existingActivity.Name = request.Name;
        existingActivity.Theme = request.Theme;
        existingActivity.Type = request.Type;
        existingActivity.Description = request.Description;
        existingActivity.StartDate = request.StartDate;
        existingActivity.EndDate = request.EndDate;
        existingActivity.StartTime = request.StartTime;
        existingActivity.EndTime = request.EndTime;
        existingActivity.MaxParticipants = request.MaxParticipants;
        existingActivity.CertificationHours = request.CertificationHours;

        return existingActivity;
    }

    public static FindByFilterResponse ToFindResponse(this Activity Activity)
    {
        return new FindByFilterResponse(
            Activity.Name,
            Activity.Theme,
            Activity.Type,
            Activity.Description,
            Activity.StartDate,
            Activity.EndDate,
            Activity.StartTime,
            Activity.EndTime,
            Activity.MaxParticipants,
            Activity.CertificationHours
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

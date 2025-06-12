namespace Domain.Entities;

public sealed class Activity : BaseEntity
{
    public string Name { get; set; }
    public string Theme { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public int MaxParticipants { get; set; }
    public TimeSpan CertificationHours { get; set; }


    public long EventId { get; set; }
    public Event Event { get; set; }

    public long SpeakerId { get; set; }
    public User Speaker { get; set; }


    public Activity(
        string name,
        string theme,
        string type,
        string description,
        DateOnly startDate,
        DateOnly endDate,
        TimeOnly startTime,
        TimeOnly endTime,
        int maxParticipants,
        TimeSpan certificationHours,
        long eventId,
        long speakerId
    )
    {
        Name = name;
        Theme = theme;
        Type = type;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        StartTime = startTime;
        EndTime = endTime;
        MaxParticipants = maxParticipants;
        CertificationHours = certificationHours;
        EventId = eventId;
        SpeakerId = speakerId;
    }
    
    public Activity() {}

    private readonly List<Evaluation> _evaluations = new();

    public IReadOnlyCollection<Evaluation> Evaluations => _evaluations.AsReadOnly();
        

    }

namespace Domain.Entities;

public sealed class Event : BaseEntity
{
    public string Name { get; set; }
    public string Theme { get; set; }
    public string Description { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string Location { get; set; }
    public string Modality { get; set; }
    public long OrganizerId { get; set; }
    public User Organizer { get; set; }


     public Event(string name, string theme, string description, DateOnly startDate,
        DateOnly endDate, TimeOnly startTime, TimeOnly endTime, string location,
        string modality, long organizerId)
    {
        Name = name;
        Theme = theme;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        StartTime = startTime;
        EndTime = endTime;
        Location = location;
        Modality = modality;
        OrganizerId = organizerId;
    }

    public Event() {}
    private readonly List<Activity> _activities = new();
    public IReadOnlyCollection<Activity> Activities => _activities.AsReadOnly();

    

    }
namespace Domain.Entities;

public sealed class Attendance : BaseEntity
{
    public bool IsPresent { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }

    public long ActivityId { get; set; }
    public Activity Activity { get; set; }

    public Attendance(long userId, long activityId, bool isPresent)
    {
        UserId = userId;
        ActivityId = activityId;
        IsPresent = isPresent;
    }
    public Attendance() { }

    }

namespace Domain.Entities;

public sealed class Attendance : BaseEntity
{
    public bool IsPresent { get; set; }
    public DateTime? ConfirmationDate { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }

    public long ActivityId { get; set; }
    public Activity Activity { get; set; }

    public Attendance(long userId, long activityId, bool isPresent)
    {
        UserId = userId;
        ActivityId = activityId;
        IsPresent = isPresent;
        if (isPresent) ConfirmationDate = DateTime.UtcNow;
    }
    public Attendance() { }


    public void ConfirmPresence()
    {
        IsPresent = true;
        ConfirmationDate = DateTime.UtcNow;
    }

    public void DisconfirmPresence()
    {
        IsPresent = false;
        ConfirmationDate = DateTime.UtcNow;
    }

    }



namespace Domain.Entities;

public sealed class Evaluation : BaseEntity
{
    public int Rating { get; set; }
    public string Comment { get; set; }

    public long ActivityId { get; set; }
    public Activity Activity { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }


    public Evaluation(
        int rating,
        string comment,
        long activityId,
        long userId
    )
    {
        Rating = rating;
        Comment = comment;
        UserId = userId;
        ActivityId = activityId;
    }
    public Evaluation() { }

    }

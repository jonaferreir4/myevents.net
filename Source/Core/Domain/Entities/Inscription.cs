
namespace Domain.Entities;

public sealed class Inscription : BaseEntity
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long EventId { get; set; }
    public Event Event { get; set; }



    public Inscription(long userId, long eventId)
    {
        UserId = userId;
        EventId = eventId;
    }

    public Inscription(){}
}
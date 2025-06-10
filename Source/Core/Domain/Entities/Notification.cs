

namespace Domain.Entities;
    public  sealed class Notification: BaseEntity
    {
      public string Message { get; private set;}
      public DateTime SetAt { get; private set; }

      public long UserId { get; private set; }
      public User User { get; private set; }
    }
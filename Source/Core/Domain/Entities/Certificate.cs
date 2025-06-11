
namespace Domain.Entities;

    public  sealed class Certificate: BaseEntity
    {

      public  string Name { get; private set; }
      public  TimeSpan TotalTime { get; private set; }

      public int ActivityId { get; private set; }
      public Activity Activity { get; private set;  }

      public int UserId { get; private set; }
      public User user  { get; private set; }
        
    }
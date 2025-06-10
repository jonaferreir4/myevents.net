

namespace Domain.Entities;
    public  sealed class Evaluation: BaseEntity
    {
        public int Rating { get; private set; }
        public string Comment { get; private set; }

        public long ActivityId { get; private set; }
        public Activity Activity { get; private set; }

        public string UserId { get; private set; }
        public User User { get; private set; }

    }

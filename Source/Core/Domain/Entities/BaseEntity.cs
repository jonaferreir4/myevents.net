
namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; private set; }
        public DateTime CreatedOn { get; init; } = DateTime.UtcNow;
        public DateTime UpdatedOn { get; init; } = DateTime.UtcNow;
    }
}
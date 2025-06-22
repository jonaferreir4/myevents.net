
namespace Library.Http.DTO;

public class ActivityFilter
{
    public string? Name { get; set; }
    public DateOnly? StartDate { get; set; }
    public TimeOnly StartTime { get; set; }
    public long? EventId { get; set; } 
    public TimeSpan CertificationHours { get; set; }
}
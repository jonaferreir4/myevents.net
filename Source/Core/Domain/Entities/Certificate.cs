
namespace Domain.Entities;

public sealed class Certificate : BaseEntity
{

  public string Name { get; set; }
  public decimal TotalHours { get; set; }
  public long ActivityId { get; set; }
  public Activity Activity { get; set; }
  public DateTime IssueDate { get; }
  public string VerificationCode { get; }
  public long UserId { get; set; }
  public User User { get; set; }
  public bool IsSpeakerCertificate { get; set; }

  public Certificate(string name, decimal totalHours, long activityId, long userId)
  {
    Name = name;
    TotalHours = totalHours;
    ActivityId = activityId;
    UserId = userId;
    IssueDate = DateTime.UtcNow;
    VerificationCode = GenerateVerificationCode();
  }


  public Certificate() { }


  private static string GenerateVerificationCode()
  {
    return Guid.NewGuid().ToString("N")[..12].ToUpper();
  }
}
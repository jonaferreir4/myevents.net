using Library.Enums;

namespace Domain.Entities;

public sealed class Notification : BaseEntity
{
  public string Title { get; private set; }
  public string Message { get; private set; }
  public DateTime CreatedAt { get; private set; }
  public DateTime? ReadAt { get; private set; }
  public bool IsRead => ReadAt.HasValue;

  public NotificationType Type { get; private set; }

  public long? RelatedEntityId { get; private set; }  // ID da entidade relacionada
  public string RelatedEntityType { get; private set; } // "Certificate", "Attendance", etc.

  public long UserId { get; private set; }
  public User User { get; private set; }

  // Status adicional para notificações importantes
  public bool IsUrgent { get; private set; }

  // Métodos
  public void MarkAsRead()
  {
    ReadAt = DateTime.UtcNow;
  }

  // Construtor
  public Notification(
      string title,
      string message,
      long userId,
      NotificationType type,
      bool isUrgent = false,
      long? relatedEntityId = null,
      string relatedEntityType = null)
  {
    Title = title;
    Message = message;
    UserId = userId;
    Type = type;
    IsUrgent = isUrgent;
    RelatedEntityId = relatedEntityId;
    RelatedEntityType = relatedEntityType;
    CreatedAt = DateTime.UtcNow;
  }

  public Notification () {}

}
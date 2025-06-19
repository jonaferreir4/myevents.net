using Domain.Contracts.Data.Repositories.Base;

namespace Domain.Contracts.Data.Repositories.Notification;

public interface INotificationReadRepository : IReadOnlyRepository<Entities.Notification>
{
    Task<Entities.Notification?> FindByIdAsync(long id);
    Task<IEnumerable<Entities.Notification>> FindByUserIdAsync(long userId);
    Task<IEnumerable<Entities.Notification>> FindByEventIdAsync(long eventId);

    }
  

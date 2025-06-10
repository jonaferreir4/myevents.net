using Domain.Contracts.Data.Repositories.Base;

namespace Domain.Contracts.Data.Repositories.Attendance;

public interface IAttendanceReadRepository : IReadOnlyRepository<Entities.Attendance>
{
    Task<Entities.Attendance?> FindByIdAsync(long id);
    Task<Entities.Attendance> FindByUserIdAndActivityIdAsync(long userId, long activityId);
    Task<IEnumerable<Entities.Attendance>> FindByPresentUserIdAsync(long userId, bool isPresent);
    Task<IEnumerable<Entities.Attendance>> FindByUserIdAsync(long userId);
    Task<IEnumerable<Entities.Attendance>> FindByActivityIdAsync(long activityId);

    }
  

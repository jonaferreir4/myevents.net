using Domain.Contracts.Data.Repositories.Base;

namespace Domain.Contracts.Data.Repositories.Activity
{
    public interface IActivityReadRepository : IReadOnlyRepository<Entities.Activity>
    {
        Task<Entities.Activity?> FindByIdAsync(long id);
        Task<Entities.Activity?> FindByNameAsync(string name);
        Task<IEnumerable<Entities.Activity>> FindByThemeAsync(string theme);
        Task<IEnumerable<Entities.Activity>> FindByStartDateAsync(DateOnly startDate);
        Task<IEnumerable<Entities.Activity>> FindByEventIdAsync(long eventId);
    
    }
  
}
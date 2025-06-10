using Domain.Contracts.Data.Repositories.Base;

namespace Domain.Contracts.Data.Repositories.Event
{
    public interface IEventReadRepository : IReadOnlyRepository<Entities.Event>
    {
        Task<Entities.Event?> FindByIdAsync(long id);
        Task<Entities.Event?> FindByNameAsync(string name);
        Task<IEnumerable<Entities.Event>> FindByStartDateAsync(DateOnly startDate);
        Task<IEnumerable<Entities.Event>> FindByLocationAsync(string location);
        Task<IEnumerable<Entities.Event>> FindByOrganizerIdAsync(long organizerId);
        Task<IEnumerable<Entities.Event>> FindByModalityAsync(string modality);
        Task<IEnumerable<Entities.Event>> FindByThemeAsync(string theme);
        Task<IEnumerable<Entities.Event>> FindUpcomingEventsAsync(DateOnly fromDate);
        Task<IEnumerable<Entities.Event>> FindPastEventsAsync(DateOnly toDate);
    }
  
}
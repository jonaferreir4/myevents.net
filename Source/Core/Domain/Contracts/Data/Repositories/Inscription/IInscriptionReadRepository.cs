using Domain.Contracts.Data.Repositories.Base;

namespace Domain.Contracts.Data.Repositories.Inscription;

public interface IInscriptionReadRepository : IReadOnlyRepository<Entities.Inscription>
{
    Task<Entities.Inscription> FindByUserIdAndEventIdAsync(long userId, long eventId);
    Task<Entities.Inscription?> FindByIdAsync(long id);
    Task<IEnumerable<Entities.Inscription>> FindByUserIdAsync(long userId);
    Task<IEnumerable<Entities.Inscription>> FindByEventIdAsync(long eventId);

    }
  

using Domain.Contracts.Data.Repositories.Base;

namespace Domain.Contracts.Data.Repositories.Certificate;

public interface ICertificateReadRepository : IReadOnlyRepository<Entities.Certificate>
{
    Task<Entities.Certificate?> FindByIdAsync(long id);
    Task<Entities.Certificate?> FindByIdWithRelationsAsync(long id);
    Task<Entities.Certificate?> FindByNameAsync(string name);
    Task<Entities.Certificate> FindByUserIdAndActivityIdAsync(long userId, long activityId);
    Task<IEnumerable<Entities.Certificate>> FindByUserIdAsync(long userId);
    Task<IEnumerable<Entities.Certificate>> FindByActivityIdAsync(long activityId);

    }
  

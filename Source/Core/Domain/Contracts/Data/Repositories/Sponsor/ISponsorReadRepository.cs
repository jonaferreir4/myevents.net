using Domain.Contracts.Data.Repositories.Base;

namespace Domain.Contracts.Data.Repositories.Sponsor
{
    public interface ISponsorReadRepository : IReadOnlyRepository<Entities.Sponsor>
    {
        Task<Entities.Sponsor?> FindByIdAsync(long id);
        Task<Entities.Sponsor?> FindByNameAsync(string name);
    }
  
}
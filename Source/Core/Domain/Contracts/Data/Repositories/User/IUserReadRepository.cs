using Domain.Contracts.Data.Repositories.Base;

namespace Domain.Contracts.Data.Repositories.User
{
    public interface IUserReadRepository: IReadOnlyRepository<Entities.User>
    {
        Task<Entities.User?> FindByIdAsync(long id);
        Task<bool> FindActiveEmailAsync(string email);
        Task<Entities.User?> FindByEmailAsync(string email);
    }
  
}
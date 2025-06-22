using System.Linq.Expressions;
using Domain.Contracts.Data.Repositories.Base;
namespace Domain.Contracts.Data.Repositories.Event
{
    public interface IEventReadRepository : IReadOnlyRepository<Entities.Event>
    {
    Task<Entities.Event?> FindByIdAsync(long id);
    }
  
}
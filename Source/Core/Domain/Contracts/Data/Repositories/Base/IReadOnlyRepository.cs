
using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Contracts.Data.Repositories.Base
{
    public interface IReadOnlyRepository<T> where T: BaseEntity
    {
        Task<IList<T>> FindAllAsync(long  wrapperId);
        Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> predicate);
        Task<T?> FindByIdAsync(int entityId, int wrapperId);
    }
}
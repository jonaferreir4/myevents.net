using Domain.Entities;

namespace Domain.Contracts.Data.Repositories.Base;
    public interface IWriteOnlyRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(long id);   
    }

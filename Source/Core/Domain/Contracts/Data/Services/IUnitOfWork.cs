
namespace Domain.Contracts.Data.Services;
    public interface IUnitOfWork
    {
        Task CommitAsync();   
    }
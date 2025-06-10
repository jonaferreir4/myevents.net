using Domain.Contracts.Data.Repositories.Base;

namespace Domain.Contracts.Data.Repositories.User;
    
    public interface IUserWriteRepository: IWriteOnlyRepository<Entities.User>;
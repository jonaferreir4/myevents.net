using Domain.Contracts.Data.Repositories.Base;

namespace Domain.Contracts.Data.Repositories.Activity;
    
    public interface IActivityWriteRepository: IWriteOnlyRepository<Entities.Activity>;
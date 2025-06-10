using Domain.Contracts.Data.Repositories.Base;

namespace Domain.Contracts.Data.Repositories.Event;
    
    public interface IEventWriteRepository: IWriteOnlyRepository<Entities.Event>;
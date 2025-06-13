using Domain.Contracts.Data.Repositories.Base;

namespace Domain.Contracts.Data.Repositories.Sponsor;
    
    public interface ISponsorWriteRepository: IWriteOnlyRepository<Entities.Sponsor>;
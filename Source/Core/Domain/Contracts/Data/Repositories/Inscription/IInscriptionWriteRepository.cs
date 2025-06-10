using Domain.Contracts.Data.Repositories.Base;

namespace Domain.Contracts.Data.Repositories.Inscription;
    
    public interface IInscriptionWriteRepository: IWriteOnlyRepository<Entities.Inscription>;
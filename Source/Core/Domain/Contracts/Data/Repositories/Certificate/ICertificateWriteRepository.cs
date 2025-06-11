using Domain.Contracts.Data.Repositories.Base;

namespace Domain.Contracts.Data.Repositories.Certificate;
    
    public interface ICertificateWriteRepository: IWriteOnlyRepository<Entities.Certificate>;
using Domain.Contracts.Data.Repositories.Base;

namespace Domain.Contracts.Data.Repositories.Attendance;
    
    public interface IAttendanceWriteRepository: IWriteOnlyRepository<Entities.Attendance>;
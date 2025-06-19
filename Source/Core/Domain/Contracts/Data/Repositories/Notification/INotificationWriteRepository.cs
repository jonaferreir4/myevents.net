using Domain.Contracts.Data.Repositories.Base;

namespace Domain.Contracts.Data.Repositories.Notification;
    
    public interface INotificationWriteRepository: IWriteOnlyRepository<Entities.Notification>;
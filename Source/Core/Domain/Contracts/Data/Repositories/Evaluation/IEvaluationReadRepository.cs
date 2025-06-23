using Domain.Contracts.Data.Repositories.Base;

namespace Domain.Contracts.Data.Repositories.Evaluation;

public interface IEvaluationReadRepository : IReadOnlyRepository<Entities.Evaluation>
{
    Task<Entities.Evaluation?> FindByIdAsync(long id);
    Task<Entities.Evaluation> FindByUserIdAndActivityIdAsync(long userId, long activityId);
    Task<IEnumerable<Entities.Evaluation>> FindByUserIdAsync(long userId);
    Task<IEnumerable<Entities.Evaluation>> FindByActivityIdAsync(long activityId);

    }
  

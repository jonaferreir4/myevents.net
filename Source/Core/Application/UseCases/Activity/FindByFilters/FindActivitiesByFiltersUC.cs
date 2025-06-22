using System.Linq.Expressions;
using Application.Mappings;
using Domain.Contracts.Data.Repositories.Activity;
using Library.Http.DTO;
using Library.Http.Responses.Activity;

namespace Application.UseCases.Activity.FindByFilters;

public class FindActivitiesByFiltersUC(
    IActivityReadRepository readRepo
) : IFindActivitiesByFiltersUC
{
    public async Task<IEnumerable<FindByFilterResponse>> FindActivitiesByFiltersAsync(ActivityFilter filter)
    {
        Expression<Func<Domain.Entities.Activity, bool>> predicate = e =>
        (string.IsNullOrEmpty(filter.Name) || e.Name.Contains(filter.Name)) &&
        (!filter.StartDate.HasValue || e.StartDate >= filter.StartDate.Value) &&
        (filter.StartTime == default || e.StartTime >= filter.StartTime) &&
        (!filter.EventId.HasValue || e.EventId == filter.EventId.Value) &&
        (filter.CertificationHours == default || e.CertificationHours >= filter.CertificationHours);

        var activities = await readRepo.QueryAsync(predicate);

        return activities.Select(activity => activity.ToFindResponse());
    }
}
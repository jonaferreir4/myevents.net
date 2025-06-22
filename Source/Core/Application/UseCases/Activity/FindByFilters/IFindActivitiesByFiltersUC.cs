using Library.Http.DTO;
using Library.Http.Responses.Activity;

namespace Application.UseCases.Activity.FindByFilters;
    public interface IFindActivitiesByFiltersUC
    {
    public Task<IEnumerable<FindByFilterResponse>> FindActivitiesByFiltersAsync(ActivityFilter filter);
    }
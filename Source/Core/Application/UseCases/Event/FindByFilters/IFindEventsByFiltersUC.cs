using Library.Http.DTO;
using Library.Http.Responses.Event;

namespace Application.UseCases.Event.FindByFilters;
    public interface IFindEventsByFiltersUC
    {
    public Task<IEnumerable<FindByFilterResponse>> FindEventsByFiltersAsync(EventFilter filter);
    }
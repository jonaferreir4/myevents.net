using System.Linq.Expressions;
using Application.Mappings;
using Domain.Contracts.Data.Repositories.Event;
using Library.Http.DTO;
using Library.Http.Responses.Event;

namespace Application.UseCases.Event.FindByFilters;
    public class FindEventsByFiltersUC(
        IEventReadRepository readRepo
    ): IFindEventsByFiltersUC
    {
    public async Task<IEnumerable<FindByFilterResponse>> FindEventsByFiltersAsync(EventFilter filter)
    {
        Expression<Func<Domain.Entities.Event, bool>> predicate = e =>
        (string.IsNullOrEmpty(filter.Name) || e.Name.Contains(filter.Name)) &&
        (!filter.StartDate.HasValue || e.StartDate >= DateOnly.FromDateTime(filter.StartDate.Value)) &&
        (string.IsNullOrEmpty(filter.Location) || e.Location.Contains(filter.Location)) &&
        (!filter.OrganizerId.HasValue || e.OrganizerId == filter.OrganizerId);

        var events = await readRepo.QueryAsync(predicate);

        return events.Select(e => e.ToFindResponse());
    }
    }

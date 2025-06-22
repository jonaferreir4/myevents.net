
using Domain.Contracts.Data.Repositories.Event;
using Library.Exceptions;

namespace Application.UseCases.Event.FindById;

public class FindEventByIdUC(
    IEventReadRepository readRepo
) : IFindEventByIdUC
{
    public Task<Domain.Entities.Event?> FindEventById(long id)
    {
        _ = readRepo.FindByIdAsync(id) ??
        throw new NotFoundException("Event", id);

        return readRepo.FindByIdAsync(id);
    }
}

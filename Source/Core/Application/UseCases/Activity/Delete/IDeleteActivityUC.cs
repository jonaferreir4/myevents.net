
using Library.Http.Responses.Activity;

namespace Application.UseCases.Activity.Delete;
    public interface IDeleteActivityUC
    {
    public Task<DeleteActivityResponse> DeleteActivity(long eventId, long id);
}

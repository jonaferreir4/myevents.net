
namespace Application.UseCases.Activity.Delete;
    public interface IDeleteActivityUC
    {
    public Task<DeleteActivityResponse> DeleteActivity(long eventId, long id);
}

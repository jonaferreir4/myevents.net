
namespace Application.UseCases.Event.Delete;
    public interface IDeleteEventUC
    {
    public Task<DeleteEventResponse> DeleteEvent(long id);
}

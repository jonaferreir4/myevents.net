
namespace Application.UseCases.Event.Update;
    public interface IUpdateEventUC
    {
        public Task<UpdateEventResponse> UpdateEvent(long id, UpdateEventRequest request);
    }

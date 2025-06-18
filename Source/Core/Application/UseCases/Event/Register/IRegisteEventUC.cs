
using Library.Http.Requests.Event;
using Library.Http.Responses.Event;

namespace Application.UseCases.Event.Register;
    public interface IRegisterEventUC
    {
        public Task<RegisterEventResponse> RegisterEvent(RegisterEventRequest request);
    }

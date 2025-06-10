
namespace Application.UseCases.Event.Register;
    public interface IRegisterEventUC
    {
        public Task<RegisterEventResponse> RegisterEvent(RegisterEventRequest request);
    }

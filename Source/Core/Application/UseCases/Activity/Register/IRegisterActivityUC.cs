using Library.Http.Requests.Activity;
using Library.Http.Responses.Activity;

namespace Application.UseCases.Activity.Register;
    public interface IRegisterActivityUC
    {
        public Task<RegisterActivityResponse> RegisterActivity(long eventId, RegisterActivityRequest request);
    }

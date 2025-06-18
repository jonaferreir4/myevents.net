
using Library.Http.Requests.Activity;
using Library.Http.Responses.Activity;

namespace Application.UseCases.Activity.Update;
    public interface IUpdateActivityUC
    {
        public Task<UpdateActivityResponse> UpdateActivity(long eventId, long id, UpdateActivityRequest request);
    }

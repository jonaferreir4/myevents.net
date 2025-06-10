
namespace Application.UseCases.Activity.Update;
    public interface IUpdateActivityUC
    {
        public Task<UpdateActivityResponse> UpdateActivity(long eventId, long id, UpdateActivityRequest request);
    }


using Library.Http.Requests.Sponsor;
using Library.Http.Responses.Sponsor;

namespace Application.UseCases.Sponsor.Update;
    public interface IUpdateSponsorUC
    {
        public Task<UpdateSponsorResponse> UpdateSponsor(long id, UpdateSponsorRequest request);
    }

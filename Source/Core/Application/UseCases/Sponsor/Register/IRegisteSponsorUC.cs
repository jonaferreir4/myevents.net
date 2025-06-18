
using Library.Http.Requests.Sponsor;
using Library.Http.Responses.Sponsor;

namespace Application.UseCases.Sponsor.Register;
    public interface IRegisterSponsorUC
    {
        public Task<RegisterSponsorResponse> RegisterSponsor(RegisterSponsorRequest request);
    }

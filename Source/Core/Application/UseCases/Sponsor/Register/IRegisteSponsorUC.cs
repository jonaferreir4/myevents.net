
namespace Application.UseCases.Sponsor.Register;
    public interface IRegisterSponsorUC
    {
        public Task<RegisterSponsorResponse> RegisterSponsor(RegisterSponsorRequest request);
    }

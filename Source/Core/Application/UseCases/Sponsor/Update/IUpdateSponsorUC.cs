
namespace Application.UseCases.Sponsor.Update;
    public interface IUpdateSponsorUC
    {
        public Task<UpdateSponsorResponse> UpdateSponsor(long id, UpdateSponsorRequest request);
    }

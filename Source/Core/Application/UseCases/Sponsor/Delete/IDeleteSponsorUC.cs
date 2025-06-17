
namespace Application.UseCases.Sponsor.Delete;
    public interface IDeleteSponsorUC
    {
    public Task<DeleteSponsorResponse> DeleteSponsor(long id);
}


namespace Application.UseCases.Inscription.Register;
    public interface IRegisterInscriptionUC
    {
        public Task<RegisterInscriptionResponse> RegisterInscription(long eventId);
    }

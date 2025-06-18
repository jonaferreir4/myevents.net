
using Library.Http.Responses.Inscription;

namespace Application.UseCases.Inscription.Register;
    public interface IRegisterInscriptionUC
    {
        public Task<RegisterInscriptionResponse> RegisterInscription(long eventId);
    }

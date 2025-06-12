
namespace Application.UseCases.Certificate.Register;
    public interface IRegisterCertificateUC
    {
        public Task<RegisterCertificateResponse> RegisterCertificate(long activityId);
    }

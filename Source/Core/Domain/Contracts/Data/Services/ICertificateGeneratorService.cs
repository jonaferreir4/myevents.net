namespace Domain.Contracts.Data.Services;

public interface ICertificateGeneratorService
{
        Task GenerateCertificateForUser(long activityId, long userId);
}

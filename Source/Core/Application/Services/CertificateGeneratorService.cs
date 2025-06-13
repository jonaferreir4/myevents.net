using Domain.Contracts.Data.Repositories.Activity;
using Domain.Contracts.Data.Repositories.Attendance;
using Domain.Contracts.Data.Repositories.Certificate;
using Domain.Contracts.Data.Services;
using Domain.Entities;

namespace Application.Services;

public class CertificateGeneratorService(
    ICertificateWriteRepository certificateWriteRepo,
    IAttendanceReadRepository attendanceReadRepo,
    IActivityReadRepository activityReadRepo,
    IUnitOfWork unitOfWork) : ICertificateGeneratorService
{
    private readonly ICertificateWriteRepository _certificateWriteRepo = certificateWriteRepo;
    private readonly IAttendanceReadRepository _attendanceReadRepo = attendanceReadRepo;
    private readonly IActivityReadRepository _activityReadRepo = activityReadRepo;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task GenerateCertificateForUser(long activityId, long userId)
{
    var activity = await _activityReadRepo.FindByIdAsync(activityId);
    if (activity == null) throw new KeyNotFoundException("Activity not found");

    var certificateName = $"{activity.Name} - {userId}";

    var certificate = new Certificate(
        name: certificateName,
        totalHours: Convert.ToDecimal(activity.CertificationHours.TotalHours),
        activityId: activityId,
        userId: userId
    );

    await _certificateWriteRepo.CreateAsync(certificate);
    await _unitOfWork.CommitAsync();
}

}

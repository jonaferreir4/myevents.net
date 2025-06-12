using Domain.Contracts.Data.Repositories.Activity;
using Domain.Contracts.Data.Repositories.Attendance;
using Domain.Contracts.Data.Repositories.Certificate;
using Domain.Contracts.Data.Services;
using Domain.Entities;

namespace Application.Services;

public class CertificateGeneratorService
{
    private readonly ICertificateWriteRepository _certificateWriteRepo;
    private readonly IAttendanceReadRepository _attendanceReadRepo;
    private readonly IActivityReadRepository _activityReadRepo;
    private readonly IUnitOfWork _unitOfWork;

    public CertificateGeneratorService(
        ICertificateWriteRepository certificateWriteRepo,
        IAttendanceReadRepository attendanceReadRepo,
        IActivityReadRepository activityReadRepo,
        IUnitOfWork unitOfWork)
    {
        _certificateWriteRepo = certificateWriteRepo;
        _attendanceReadRepo = attendanceReadRepo;
        _activityReadRepo = activityReadRepo;
        _unitOfWork = unitOfWork;
    }

    public async Task GenerateCertificatesForActivity(int activityId)
    {
        var activity = await _activityReadRepo.FindByIdAsync(activityId);
        if (activity == null) throw new KeyNotFoundException("Activity not found");

        var attendees = await _attendanceReadRepo.FindByActivityIdAsync(activityId);

        foreach (var attendee in attendees)
        {
            var certificateName = $"{activity.Name} - {attendee.User.Name}";

            var certificate = new Certificate(
                name: certificateName,
                totalHours: Convert.ToDecimal(activity.CertificationHours.TotalHours),
                activityId: activityId,
                userId: attendee.UserId
            );

            await _certificateWriteRepo.CreateAsync(certificate);
        }

        await _unitOfWork.CommitAsync();
    }
}

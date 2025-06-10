
namespace Application.UseCases.Attendance.Register;
    public interface IRegisterAttendanceUC
    {
        public Task<RegisterAttendanceResponse> RegisterAttendance(long activityId);
    }

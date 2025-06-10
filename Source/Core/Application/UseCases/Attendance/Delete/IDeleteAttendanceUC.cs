
namespace Application.UseCases.Attendance.Delete;
    public interface IDeleteAttendanceUC
    {
    public Task<DeleteAttendanceResponse> DeleteAttendance(long id, long activityId);
}

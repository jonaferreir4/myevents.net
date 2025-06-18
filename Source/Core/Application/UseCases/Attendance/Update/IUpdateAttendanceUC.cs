
using Library.Http.Responses.Attendance;

namespace Application.UseCases.Attendance.Update;
    public interface IUpdateAttendanceUC
    {
        public Task<UpdateAttendanceResponse> UpdateAttendance(long id);
    }

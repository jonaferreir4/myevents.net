using DAO.Context;
using Domain.Contracts.Data.Repositories.Attendance;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAO.Repositories;

public class AttendanceRepository(AppDbContext _context) : BaseRepository<Attendance>(_context), IAttendanceReadRepository, IAttendanceWriteRepository
{
    public async Task<IList<Attendance>> FindAllAsync(int wrapperId)
    {
         return await _context.Attendances.ToListAsync();
    }

    public async Task<IEnumerable<Attendance>> FindByActivityIdAsync(long  activityId)
    {
        return await _context.Attendances
            .Where(i => i.ActivityId == activityId)
            .ToListAsync();
    }

    public async Task<Attendance?> FindByIdAsync(long id)
    {
        return await _context.Set<Attendance>().FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<Attendance?> FindByIdAsync(int entityId, int wrapperId)
    {
          Attendance? Attendance = await _context.Attendances.FindAsync(entityId, wrapperId);

        return Attendance;
    }

    public async Task<IEnumerable<Attendance>> FindByPresentUserIdAsync(long userId, bool isPresent)
    {
        return  await _context.Attendances
            .Where(i => i.UserId == userId && i.IsPresent == isPresent)
            .ToListAsync();
    }

    public async Task<Attendance> FindByUserIdAndActivityIdAsync(long userId, long activityId)
    {
       return await _context.Attendances
        .FirstOrDefaultAsync(i => i.UserId == userId && i.ActivityId == activityId);
    }

    public async Task<IEnumerable<Attendance>> FindByUserIdAsync(long userId)
    {
        return await _context.Attendances
            .Where(i => i.UserId == userId)
            .ToListAsync();
    }
}
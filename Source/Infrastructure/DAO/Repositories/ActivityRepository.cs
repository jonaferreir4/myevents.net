using DAO.Context;
using Domain.Contracts.Data.Repositories.Activity;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAO.Repositories
{
    public class ActivityRepository(AppDbContext _context) : BaseRepository<Activity>(_context),
        IActivityReadRepository, IActivityWriteRepository
    {
       

        public async Task<IList<Activity>> FindAllAsync(int wrapperId)
        {
            return await _context.Activities.ToListAsync();
        }

        public async  Task<IEnumerable<Activity>> FindByEventIdAsync(long eventId)
        {
            return await _context.Activities
            .Where(e => e.EventId == eventId)
            .ToListAsync();
        }

        public Task<Activity?> FindByIdAsync(long id)
        {
            return _context.Set<Activity>().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Activity?> FindByIdAsync(int entityId, int wrapperId)
        {
            Activity? actv = await _context.Activities.FindAsync(entityId, wrapperId);
            return actv;
        }

        public async Task<Activity?> FindByNameAsync(string name)
        {
            return await _context.Activities.FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task<IEnumerable<Activity>> FindByStartDateAsync(DateOnly startDate)
        {
            return await _context.Activities
            .Where(e => e.StartDate == startDate)
            .ToListAsync();
        }

        public async Task<IEnumerable<Activity>> FindByThemeAsync(string theme)
        {
           return await _context.Activities
            .Where(e => e.Theme ==  theme)
            .ToListAsync();
        }

    }
}
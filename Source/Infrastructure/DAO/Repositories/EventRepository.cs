using DAO.Context;
using Domain.Contracts.Data.Repositories.Event;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAO.Repositories;

public class EventRepository(AppDbContext _context) : BaseRepository<Event>(_context), IEventReadRepository, IEventWriteRepository
{
    public async Task<IList<Event>> FindAllAsync(int wrapperId)
    {
        return await _context.Events.ToListAsync();
    }

    public  async Task<Event?> FindByIdAsync(long id)
    {
        return await _context.Set<Event>().FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<Event?> FindByIdAsync(int entityId, int wrapperId)
    {
            Event? evt = await _context.Events.FindAsync(entityId, wrapperId);

        return evt;
    }

    public async Task<IEnumerable<Event>> FindByLocationAsync(string location)
    {
        return await _context.Events
            .Where(e => e.Location == location)
            .ToListAsync();
    }

    public async Task<IEnumerable<Event>> FindByModalityAsync(string modality)
    {
        return await _context.Events
        .Where(e => e.Modality == modality)
        .ToListAsync();
    }

    public async Task<Event?> FindByNameAsync(string name)
    {
        return await _context.Events.FirstOrDefaultAsync(e => e.Name == name);
    }

    public async Task<IEnumerable<Event>> FindByOrganizerIdAsync(long organizerId)
    {
        return await _context.Events
            .Where(e => e.OrganizerId == organizerId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Event>> FindByStartDateAsync(DateOnly startDate)
    {
        return await _context.Events
            .Where(e => e.StartDate == startDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Event>> FindByThemeAsync(string theme)
    {
        return await _context.Events
            .Where(e => e.Theme == theme)
            .ToListAsync();
    }

    public async Task<IEnumerable<Event>> FindPastEventsAsync(DateOnly toDate)
    {
        return await _context.Events
            .Where(e => e.StartDate < toDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Event>> FindUpcomingEventsAsync(DateOnly fromDate)
    {
        return await _context.Events
            .Where(e => e.StartDate >= fromDate)
            .ToListAsync();
    }
}

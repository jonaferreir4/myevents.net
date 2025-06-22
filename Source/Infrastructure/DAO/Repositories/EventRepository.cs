using System.Linq.Expressions;
using DAO.Context;
using Domain.Contracts.Data.Repositories.Event;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAO.Repositories;

public class EventRepository(AppDbContext _context) : BaseRepository<Event>(_context), IEventReadRepository, IEventWriteRepository
{
    public async Task<IList<Event>> FindAllAsync(long wrapperId)
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
    
    public async Task<IEnumerable<Event>> QueryAsync(Expression<Func<Event, bool>> predicate)
    {
        return await _context.Events
            .Where(predicate)
            .ToListAsync();
    }
}

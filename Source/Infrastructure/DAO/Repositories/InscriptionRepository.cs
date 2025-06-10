using DAO.Context;
using Domain.Contracts.Data.Repositories.Inscription;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAO.Repositories;

public class InscriptionRepository(AppDbContext _context) : BaseRepository<Inscription>(_context), IInscriptionReadRepository, IInscriptionWriteRepository
{
    public async Task<IList<Inscription>> FindAllAsync(int wrapperId)
    {
         return await _context.Inscriptions.ToListAsync();
    }

    public async Task<IEnumerable<Inscription>> FindByEventIdAsync(long  eventId)
    {
        return await _context.Inscriptions
            .Where(i => i.EventId == eventId)
            .ToListAsync();
    }

    public async Task<Inscription?> FindByIdAsync(long id)
    {
        return await _context.Set<Inscription>().FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<Inscription?> FindByIdAsync(int entityId, int wrapperId)
    {
          Inscription? inscription = await _context.Inscriptions.FindAsync(entityId, wrapperId);

        return inscription;
    }

    public async Task<Inscription?> FindByUserIdAndEventIdAsync(long userId, long eventId)
    {
    return await _context.Inscriptions
        .FirstOrDefaultAsync(i => i.UserId == userId && i.EventId == eventId);
    }
    public async Task<IEnumerable<Inscription>> FindByUserIdAsync(long userId)
    {
        return await _context.Inscriptions
            .Where(i => i.UserId == userId)
            .ToListAsync();
    }
}
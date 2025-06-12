
using DAO.Context;
using Domain.Contracts.Data.Repositories.Certificate;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAO.Repositories;

public class CertificateRepository(AppDbContext _context) : BaseRepository<Certificate>(_context),
ICertificateReadRepository, ICertificateWriteRepository
{
    public async Task<IList<Certificate>> FindAllAsync(int wrapperId)
    {
        return await _context.Certificates.ToListAsync();
    }

    public async Task<Certificate?> FindByIdWithRelationsAsync(long id)
    {
        return await _context.Certificates
            .Include(c => c.User)
            .Include(c => c.Activity)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Certificate>> FindByActivityIdAsync(long activityId)
    {
        return await _context.Certificates
        .Where(c => c.ActivityId == activityId)
        .ToListAsync();
    }

    public async Task<Certificate?> FindByIdAsync(long id)
    {
        return await _context.Set<Certificate>().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Certificate?> FindByIdAsync(int entityId, int wrapperId)
    {
        Certificate? certificate = await _context.Certificates.FindAsync(entityId, wrapperId);
        return certificate;
    }

    public async Task<Certificate?> FindByNameAsync(string name)
    {
        return await _context.Set<Certificate>().FirstOrDefaultAsync(e => e.Name == name);
    }

    public async Task<Certificate?> FindByUserIdAndActivityIdAsync(long userId, long activityId)
    {
        return await _context.Certificates
        .FirstOrDefaultAsync(i => i.UserId == userId && i.ActivityId == activityId);
    }

    public async Task<IEnumerable<Certificate>> FindByUserIdAsync(long userId)
    {
        return await _context.Certificates
        .Where(c => c.UserId == userId)
        .ToListAsync();
    }
}
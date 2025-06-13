using DAO.Context;
using Domain.Contracts.Data.Repositories.Sponsor;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAO.Repositories;

public class SponsorRepository(AppDbContext _context) : BaseRepository<Sponsor>(_context), ISponsorReadRepository, ISponsorWriteRepository
{
    public async Task<IList<Sponsor>> FindAllAsync(int wrapperId)
    {
        return await _context.Sponsors.ToListAsync();
    }

    public async Task<Sponsor?> FindByIdAsync(long id)
    {
         return await _context.Set<Sponsor>().FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Sponsor?> FindByIdAsync(int entityId, int wrapperId)
    {
         Sponsor? sponsor = await _context.Sponsors.FindAsync(entityId, wrapperId);

        return sponsor;
    }

    public  async Task<Sponsor?> FindByNameAsync(string name)
    {
         return await _context.Sponsors.FirstOrDefaultAsync(s => s.Name == name);
    }
}
using DAO.Context;
using Domain.Entities;
using Domain.Contracts.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DAO.Repositories;
public class BaseRepository<T>(AppDbContext context) : IWriteOnlyRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context = context;
    public async Task CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
    }

    public async  Task DeleteAsync(long id)
    {
        var entity = await _context.Set<T>().FirstOrDefaultAsync(t => t.Id == id) ??
                     throw new InvalidOperationException("Id for entry nonexistent, try another");

        _context.Remove(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        await Task.FromResult(_context.Update(entity));
    }
}
using System.Linq.Expressions;
using DAO.Context;
using Domain.Contracts.Data.Repositories.Evaluation;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAO.Repositories;

public class EvaluationRepository(AppDbContext _context) :
    BaseRepository<Evaluation>(_context), IEvaluationReadRepository, IEvaluationWriteRepository
{
    public async Task<IList<Evaluation>> FindAllAsync(long wrapperId)
    {
        return await _context.Evaluations.ToListAsync();
    }

    public async Task<IEnumerable<Evaluation>> FindByActivityIdAsync(long activityId)
    {
       return await _context.Evaluations
        .Where(e => e.ActivityId == activityId)
        .ToListAsync();
    }

    public async Task<Evaluation?> FindByIdAsync(long id)
    {
        return await _context.Set<Evaluation>().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Evaluation?> FindByIdAsync(int entityId, int wrapperId)
    {
        return await _context.Evaluations.FindAsync(entityId, wrapperId);
    }

    public async Task<Evaluation> FindByUserIdAndActivityIdAsync(long userId, long activityId)
    {
        return await _context.Evaluations
            .FirstOrDefaultAsync(e => e.UserId == userId
            && e.ActivityId == activityId);
    }

    public async Task<IEnumerable<Evaluation>> FindByUserIdAsync(long userId)
    {
        return await _context.Evaluations
        .Where(e => e.UserId == userId)
        .ToListAsync();
    }

    public Task<IEnumerable<Evaluation>> QueryAsync(Expression<Func<Evaluation, bool>> predicate)
    {
        throw new NotImplementedException();
    }
}

using DAO.Context;
using Domain.Entities;
using Domain.Contracts.Data.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace DAO.Repositories;
    public class UserRepository (AppDbContext _context): BaseRepository<User>(_context), IUserReadRepository, IUserWriteRepository
    {
        public async Task<bool> FindActiveEmailAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<User?> FindByIdAsync(long id)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<IList<User>> FindAllAsync(int wrapperId)
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> FindByIdAsync(int entityId, int wrapperId)
        {
            User? user = await _context.Users.FindAsync(entityId, wrapperId);

            return user;
        }
}
using System;
using DAO.Context;
using Domain.Contracts.Data.Services;

namespace DAO.Repositories;
    public class UnitOfWork(AppDbContext context): IUnitOfWork

    {
        private readonly AppDbContext _context = context;

        public async Task CommitAsync ()
            => await _context.SaveChangesAsync();
    }

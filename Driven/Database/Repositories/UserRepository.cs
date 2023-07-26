using Application.Contracts.Driven.EwwwDb.Repositories;
using Application.Entities;
using Application.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(EwwwDbCtx ewwwDbCtx) : base(ewwwDbCtx)
    {
    }

    public Task<User?> FindOneByAuthIdAsync(AuthId authId)
    {
        return DbSet.SingleOrDefaultAsync(u => (string)u.AuthId == (string)authId);
    }
}
using Application.Contracts.Driven.EwwwDb.Repositories;
using Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public abstract class BaseRepository<T> : IRepositoryBase<T> where T : EntityBase
{
    private protected readonly DbSet<T> DbSet;

    protected BaseRepository(EwwwDbCtx ewwwDbCtx)
    {
        DbSet = ewwwDbCtx.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
    }

    public Task<T?> FindOneByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
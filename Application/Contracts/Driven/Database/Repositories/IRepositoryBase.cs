using Application.Entities;

namespace Application.Contracts.Driven.Database.Repositories;

public interface IRepositoryBase<T> where T : EntityBase
{
    Task AddAsync(T entity);
    Task<T?> FindOneByIdAsync(Guid id);
}
using Application.Entities;

namespace Application.Contracts.Driven.EwwwDb.Repositories;

public interface IRepositoryBase<in T> where T : EntityBase
{
    Task InsertAsync(T entity);
}
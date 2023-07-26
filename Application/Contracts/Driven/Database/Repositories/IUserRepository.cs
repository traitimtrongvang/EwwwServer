using Application.Entities;
using Application.ValueObjects;

namespace Application.Contracts.Driven.Database.Repositories;

public interface IUserRepository : IRepositoryBase<User>
{
    Task<User?> FindOneByAuthIdAsync(AuthId authId);
}
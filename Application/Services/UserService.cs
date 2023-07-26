using Application.Contracts.Driven.Database.Repositories;
using Application.Entities;
using Application.Exceptions;
using Application.ValueObjects;

namespace Application.Services;

public interface IUserService
{
    Task<User> CreateUserAsync(AuthId authId);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    /// <exception cref="UserAlreadyRegisterExc"></exception>
    public async Task<User> CreateUserAsync(AuthId authId)
    {
        var user = await _userRepository.FindOneByAuthIdAsync(authId);
        if (user is not null)
            throw new UserAlreadyRegisterExc();

        return new User{AuthId = authId};
    }
}
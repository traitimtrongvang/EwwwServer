using Application.Contracts.Driven.Auth0;
using Application.Contracts.Driven.EwwwDb;
using Application.Contracts.Driven.EwwwDb.Repositories;
using Application.Contracts.Driving.Api.Dtos;
using Application.Services;
using Application.ValueObjects;

namespace Application.UseCases;

public interface IRegisterNewUser
{
    Task HandleAsync(RegisterNewUserRequest req);
}

public record RegisterNewUser : IRegisterNewUser
{
    private readonly IUserRepository _userRepository;
    private readonly IAuth0Driven _auth0Driven;
    private readonly IEwwwDbCtx _ewwwDbCtx;
    private readonly IUserService _userService;

    public RegisterNewUser(IUserRepository userRepository, IAuth0Driven auth0Driven, IEwwwDbCtx ewwwDbCtx, IUserService userService)
    {
        _userRepository = userRepository;
        _auth0Driven = auth0Driven;
        _ewwwDbCtx = ewwwDbCtx;
        _userService = userService;
    }

    public async Task HandleAsync(RegisterNewUserRequest req)
    {
        // authorize and read info, throw exception if unauthorized
        var authorInfo = _auth0Driven.AuthorizeAndReadToken(req.AccessToken);
        
        // create user, throw exception if inputs are invalid
        var authId = new AuthId(authorInfo.Id);
        var newUser = await _userService.CreateUserAsync(authId);
        
        // insert new user
        await _userRepository.AddAsync(newUser);

        // save changes
        await _ewwwDbCtx.SaveChangesAsync();
    }
}
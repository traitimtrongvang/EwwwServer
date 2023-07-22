using Application.Contracts.Driven.Auth0;
using Application.Contracts.Driven.Auth0.Dtos;
using Application.Contracts.Driven.Auth0.Exceptions;
using Auth0.Exceptions;
using Auth0.Services;

namespace Auth0;

public class Auth0Driven : IAuth0Driven
{
    private readonly ITokenService _tokenService;

    public Auth0Driven(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    public AuthorInfo AuthorizeAndReadToken(string accessToken)
    {
        try
        {
            var jwtToken = _tokenService.VerifyAndReadJwtToken(accessToken);

            return new AuthorInfo
            {
                Id = jwtToken.Payload.Sub
            };
        }
        catch (InvalidTokenExc e)
        {
            throw new UnauthorizedExc();
        }
    }
}
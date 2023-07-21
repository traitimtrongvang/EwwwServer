using Application.Contracts.Driven.Auth0.Dtos;
using Application.Contracts.Driven.Auth0.Exceptions;

namespace Application.Contracts.Driven.Auth0;

public interface IAuth0Driven
{
    /// <exception cref="UnauthorizedExc">description</exception>
    Task<AuthorInfo> AuthorizeAndReadTokenAsync(string accessToken);
}
using System.IdentityModel.Tokens.Jwt;
using Application.Contracts.Driven.Auth0.Exceptions;
using Auth0.Exceptions;
using Auth0.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Auth0.Services;

public interface ITokenService
{
    JwtSecurityToken VerifyAndReadJwtToken(string tokenStr);
}

public class TokenService : ITokenService
{
    private static readonly JwtSecurityTokenHandler TokenHandler = new();
    
    private readonly IOptions<Auth0Setting> _settings;
    private TokenValidationParameters _tokenValidationParameters = default!;

    public TokenService(IOptions<Auth0Setting> settings)
    {
        _settings = settings;
        InitTokenValidationParameters();
    }

    #region implemenetd members

    public JwtSecurityToken VerifyAndReadJwtToken(string tokenStr)
    {
        ThrowExceptionIfTokenInvalid(tokenStr);
        
        var jwtToken = TokenHandler.ReadJwtToken(tokenStr);

        return jwtToken;
    }
    
    #endregion
    
    /// <exception cref="InvalidTokenExc"></exception>
    private void ThrowExceptionIfTokenInvalid(string tokenStr)
    {
        try
        {
            TokenHandler.ValidateToken(tokenStr, _tokenValidationParameters, out _);
        }
        catch
        {
            throw new InvalidTokenExc();
        }
    }
    
    private void InitTokenValidationParameters()
    {
        _tokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = _settings.Value.Issuer,
            ValidAudiences = _settings.Value.Audiences,
            ValidateLifetime = true,
            IssuerSigningKeys = new JsonWebKeySet(_settings.Value.IssuerSigningKeysStr).GetSigningKeys(),
            RequireSignedTokens = false
        };
    }
}
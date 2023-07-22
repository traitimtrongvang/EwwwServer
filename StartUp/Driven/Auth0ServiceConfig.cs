using Auth0.Services;

namespace StartUp.Driven;

public static class Auth0ServiceConfig
{
    public static void AddAuth0Service(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
    }
}
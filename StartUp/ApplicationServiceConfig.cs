using Application.Contracts.Driven.EwwwDb;
using EwwwDb;

namespace StartUp;

public static class ApplicationServiceConfig
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IEwwwDbCtx>(
            sp => sp.GetRequiredService<EwwwDbCtx>());
    }
}
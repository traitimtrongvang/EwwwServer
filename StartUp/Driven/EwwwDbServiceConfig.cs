using EwwwDb;
using EwwwDb.Settings;
using Microsoft.EntityFrameworkCore;

namespace StartUp.Driven;

public static class EwwwDbServiceConfig
{
    public static void AddEwwwDbServices(this IServiceCollection services, IConfiguration config)
    {
        var ewwwDbSett = config.GetSection(nameof(EwwwDbSetting)).Get<EwwwDbSetting>()!;
        
        services.AddDbContext<EwwwDbCtx>(
            options => options.UseNpgsql(ewwwDbSett.ConnStr));
    }
}
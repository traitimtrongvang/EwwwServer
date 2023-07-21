using Auth0.Settings;
using EwwwDb.Settings;

namespace StartUp;

public static class CustomConfigurationBuilder
{
    public static IConfiguration BuildCustomConfiguration(this IServiceCollection services)
    {
        #region decide environment

        var configFilePath = "appsettings.json";
        
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        if (environment == Environments.Development)
        {
            configFilePath = "appsettings.Development.json";
        }

        #endregion

        var configBuilder = new ConfigurationBuilder();
        
        configBuilder.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile(configFilePath, optional: true, reloadOnChange: true);
        
        var config = configBuilder.Build();

        #region implement settings

        services.Configure<EwwwDbSetting>(
            options => config.GetSection(nameof(EwwwDbSetting)).Bind(options));

        #endregion
        
        return config;
    }
}
using Auth0.Settings;
using EwwwDb.Settings;

namespace StartUp;

public static class CustomConfigurationBuilder
{
    public static async Task<IConfiguration> BuildCustomConfigurationAsync(this IServiceCollection services)
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

        await services.ConfigureAuth0SettingAsync(config);
        
        #endregion
        
        return config;
    }

    private static async Task ConfigureAuth0SettingAsync(this IServiceCollection services, IConfiguration config)
    {
        var auth0Settings = config.GetSection(nameof(Auth0Setting)).Get<Auth0Setting>()!;
        await auth0Settings.FetchIssuerSigningKeysStrAsync();

        services.Configure<Auth0Setting>(
            options =>
            {
                config.GetSection(nameof(Auth0Setting)).Bind(options);
                options.IssuerSigningKeysStr = auth0Settings.IssuerSigningKeysStr;
            });
    }
}
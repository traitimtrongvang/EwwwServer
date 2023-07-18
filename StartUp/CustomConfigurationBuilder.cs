﻿namespace StartUp;

public static class CustomConfigurationBuilder
{
    public static async Task<IConfiguration> Build()
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

        // TODO implement your code here
        
        return config;
    }
}
using System.Text.Json;

namespace StartUp.Driving;

public static class EwwwApiServiceConfig
{
    public static void AddEwwwApiServices(this IServiceCollection services)
    {
        services.AddRouting(options => options.LowercaseUrls = true);
        
        services
            .AddControllers()
            .AddJsonOptions(
                options => options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase)
            .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        
        // services.AddJson
        
        services.AddEndpointsApiExplorer();
        
        services.AddSwaggerGen();
    }
}
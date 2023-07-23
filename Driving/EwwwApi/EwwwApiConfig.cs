using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace EwwwApi;

public static class EwwwApiConfig
{
    public static void UseEwwwApi(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    
        app.UseHttpsRedirection();
        
        app.MapControllers();
    }
}
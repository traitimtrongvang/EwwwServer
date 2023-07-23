using EwwwApi;
using StartUp;
using StartUp.Driven;
using StartUp.Driving;

var builder = WebApplication.CreateBuilder(args);

var config = await builder.Services.BuildCustomConfigurationAsync();

#region service configuration

// driven
builder.Services.AddEwwwDbServices(config);
builder.Services.AddAuth0Service();

// application
builder.Services.AddApplicationServices();

//driving
builder.Services.AddEwwwApiServices();

#endregion

var app = builder.Build();

#region app configuration

app.UseEwwwApi();

#endregion

app.Run();
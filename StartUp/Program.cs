using StartUp;
using StartUp.Driven;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Services.BuildCustomConfiguration();

#region service configuration

builder.Services.AddEwwwDbServices(config);

#endregion

var app = builder.Build();

#region app configuration

app.MapGet("/", () => "Hello World!");

#endregion

app.Run();

// var builder = WebApplication.CreateBuilder(args);
//
// // Add services to the container.
//
// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
//
// var app = builder.Build();
//
// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
//
// app.UseHttpsRedirection();
//
// app.UseAuthorization();
//
// app.MapControllers();
//
// app.Run();
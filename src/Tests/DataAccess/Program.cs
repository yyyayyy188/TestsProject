using BackEnd.Infrastructure.Infrastructure;
using BackEnd.Tests.DataAccess;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<PracticeOne>();

var app = builder.Build();

await app.InitialiseDatabaseAsync();

using (var scope = app.Services.CreateScope())
{
    var provider = scope.ServiceProvider;
    // 4.1 拿到 DbContext，或者直接拿 Practice
    var practice = provider.GetRequiredService<PracticeOne>();
    await practice.ExecuteAsync();
}

await app.RunAsync();
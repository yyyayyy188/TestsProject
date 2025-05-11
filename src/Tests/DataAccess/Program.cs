using BackEnd.Infrastructure.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

await app.InitialiseDatabaseAsync();

await app.RunAsync();
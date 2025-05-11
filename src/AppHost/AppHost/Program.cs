using Microsoft.Extensions.Configuration;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.DataAccess>("DataAccess")
       .WithEnvironment("DefaultConnection",builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Build().Run();

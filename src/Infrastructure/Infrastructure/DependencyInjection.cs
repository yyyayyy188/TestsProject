using BackEnd.Infrastructure.Common;
using BackEnd.Infrastructure.EntityframeworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackEnd.Infrastructure.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEntityFrameworkCoreInfra(configuration);

        services.AddScoped<DbContextInitializer<EntityFrameworkCoreDbContext>>();

        services.AddKeyedScoped<IAppDbContext>(
            "ef",
            (sp, _) => sp.GetRequiredService<EntityFrameworkCoreDbContext>());

        // load seed data
        return services;
    }
}
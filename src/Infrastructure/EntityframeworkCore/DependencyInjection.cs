using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.EntityframeworkCore;

public static class DependencyInjection
{
    public static IServiceCollection AddEntityFrameworkCoreInfra(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EntityFrameworkCoreDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("BackEnd.Infrastructure.Migrations") // Specify the assembly containing the migrations
            )
        );

        return services;
    }
}

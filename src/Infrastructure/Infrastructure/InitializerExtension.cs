using BackEnd.Infrastructure.EntityframeworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.Infrastructure;

public static class InitializerExtension
{
    public static void AddAsyncSeeding(this DbContextOptionsBuilder builder, IServiceProvider serviceProvider)
    {
        // builder.UseAsyncSeeding(async (context, _, ct) =>
        // {
        //     var initialiser = serviceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        //     await initialiser.SeedAsync();
        // });
    }

    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<DbContextInitializer<EntityFrameworkCoreDbContext>>();

        await initialiser.InitialiseAsync();
        await initialiser.SeedAsync();
    }
}
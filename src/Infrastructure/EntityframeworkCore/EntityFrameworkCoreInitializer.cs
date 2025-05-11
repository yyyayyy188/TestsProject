using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.EntityframeworkCore;

public class EntityFrameworkCoreInitializer(EntityFrameworkCoreDbContext dbContext)
{
    public async Task InitialiseAsync()
    {
        try
        {
            await dbContext.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
    }

}
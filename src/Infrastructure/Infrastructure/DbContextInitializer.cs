using BackEnd.Domain.Domain.User;
using BackEnd.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.Infrastructure;

public class DbContextInitializer<TDbContext>(TDbContext dbContext) where TDbContext : DbContext , IAppDbContext
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

    public async Task SeedAsync()
    {
        try
        {
            if(dbContext.Users.Any())
            {
                // complete reset the database
                // dbContext.Database.EnsureDeleted();
                // await dbContext.Database.MigrateAsync();
            }
            else
            {
                // seed the database
                await dbContext.Users.AddAsync(new User
                {
                    Name = "John Doe",
                    Password = "@passJohnDoe",
                    Email = "johndoe@test.com"
                });
                await dbContext.Users.AddAsync(new User
                {
                    Name = "John Doe2",
                    Password = "@passJohnDoe2",
                    Email = "johndoe2@test.com"
                });
                await dbContext.Users.AddAsync(new User
                {
                    Name = "John Doe3",
                    Password = "@passJohnDoe3",
                    Email = "johndoe3@test.com"
                });
                await dbContext.SaveChangesAsync();


            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
    }

}
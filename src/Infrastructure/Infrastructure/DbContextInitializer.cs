using BackEnd.Domain.Domain.Order;
using BackEnd.Domain.Domain.Product;
using BackEnd.Domain.Domain.User;
using BackEnd.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.Infrastructure;

public class DbContextInitializer<TDbContext>(TDbContext dbContext) where TDbContext : DbContext, IAppDbContext
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
            if (dbContext.Users.Any())
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
            }

            if (dbContext.Products.Any())
            {
                // complete reset the database
                // dbContext.Database.EnsureDeleted();
                // await dbContext.Database.MigrateAsync();
            }
            else
            {
                // seed the database
                // add products and orders
                await dbContext.Products.AddAsync(new Product
                {
                    Name = "Product 1",
                    Price = 10.0m,
                    Description = "Product 1 description"
                });
                await dbContext.Products.AddAsync(new Product
                {
                    Name = "Product 2",
                    Price = 20.0m,
                    Description = "Product 2 description"
                });
                await dbContext.Products.AddAsync(new Product
                {
                    Name = "Product 3",
                    Price = 30.0m,
                    Description = "Product 3 description"
                });
                await dbContext.Products.AddAsync(new Product
                {
                    Name = "Product 4",
                    Price = 40.0m,
                    Description = "Product 4 description"
                });
                await dbContext.Products.AddAsync(new Product
                {
                    Name = "Product 5",
                    Price = 50.0m,
                    Description = "Product 5 description"
                });
                await dbContext.SaveChangesAsync();
            }

            if (dbContext.Orders.Any())
            {
                // complete reset the database
                // dbContext.Database.EnsureDeleted();
                // await dbContext.Database.MigrateAsync();
            }
            else
            {
                await dbContext.Orders.AddAsync(new Order
                {
                    CustomerName = "John Doe",
                    TotalAmount = 100.0m,
                    ProductId = 1,
                    UserId = 1
                });
                await dbContext.Orders.AddAsync(new Order
                {
                    CustomerName = "John Doe2",
                    TotalAmount = 200.0m,
                    ProductId = 2,
                    UserId = 2
                });
                await dbContext.Orders.AddAsync(new Order
                {
                    CustomerName = "John Doe3",
                    TotalAmount = 300.0m,
                    ProductId = 3,
                    UserId = 3
                });
                await dbContext.Orders.AddAsync(new Order
                {
                    CustomerName = "John Doe4",
                    TotalAmount = 400.0m,
                    ProductId = 4,
                    UserId = 1
                });
                await dbContext.Orders.AddAsync(new Order
                {
                    CustomerName = "John Doe5",
                    TotalAmount = 500.0m,
                    ProductId = 5,
                    UserId = 2
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
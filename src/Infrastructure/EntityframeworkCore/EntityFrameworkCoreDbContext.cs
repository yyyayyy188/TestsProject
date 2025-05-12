using BackEnd.Domain.Domain.Order;
using BackEnd.Domain.Domain.Product;
using BackEnd.Domain.Domain.User;
using BackEnd.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.EntityframeworkCore;

public class EntityFrameworkCoreDbContext(DbContextOptions options) : BaseDbContext(options) , IAppDbContext
{
    public DbSet<User> Users {get;set;}
    public DbSet<Order> Orders {get;set;}
    public DbSet<Product> Products {get;set;}

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // Add your custom logic here if needed
        return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityFrameworkCoreTypeConfiguration).Assembly);
    }
}
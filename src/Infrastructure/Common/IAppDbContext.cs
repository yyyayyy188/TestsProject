using BackEnd.Domain.Domain.Order;
using BackEnd.Domain.Domain.Product;
using BackEnd.Domain.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.Common;

public interface IAppDbContext
{
    DbSet<User> Users { get; }
    DbSet<Order> Orders { get; }
    DbSet<Product> Products { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
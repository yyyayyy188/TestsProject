using BackEnd.Domain.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.Common;

public interface IAppDbContext
{
    DbSet<User> Users { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
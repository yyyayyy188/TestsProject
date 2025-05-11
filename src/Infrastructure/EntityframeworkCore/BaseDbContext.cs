using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.EntityframeworkCore;

public class BaseDbContext(DbContextOptions options) : DbContext(options)
{

}
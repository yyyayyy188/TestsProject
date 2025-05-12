using BackEnd.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Tests.DataAccess;

public class PracticeOne([FromKeyedServices("ef")] IAppDbContext dbContext)
{
    public async Task ExecuteAsync()
    {
        var test = await dbContext.Orders.FirstOrDefaultAsync();
        return;
    }
}
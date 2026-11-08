using Microsoft.EntityFrameworkCore;

namespace EfCoreWebApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

}
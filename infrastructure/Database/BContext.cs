using Microsoft.EntityFrameworkCore;

namespace infrastructure.Database;
public class BContext(DbContextOptions<BContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BContext).Assembly);
    }
}
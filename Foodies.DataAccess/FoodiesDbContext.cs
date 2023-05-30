using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Foodies.DataAccess;

public class FoodiesDbContext : DbContext
{
    private readonly string _dbConnection;
    
    public FoodiesDbContext(string dbConnection)
    {
        _dbConnection = dbConnection;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        
        optionsBuilder.UseNpgsql(_dbConnection)
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
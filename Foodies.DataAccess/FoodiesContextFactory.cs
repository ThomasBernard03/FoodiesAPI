using Microsoft.EntityFrameworkCore.Design;

namespace Foodies.DataAccess;

internal class FoodiesContextFactory : IDesignTimeDbContextFactory<FoodiesDbContext>
{
    public FoodiesDbContext CreateDbContext(string[] args)
    {
        const string connection = "";

        return new FoodiesDbContext(connection);
    }
}
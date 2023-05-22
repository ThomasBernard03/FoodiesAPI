using Microsoft.EntityFrameworkCore.Design;

namespace Foodies.DataAccess;

internal class FoodiesContextFactory : IDesignTimeDbContextFactory<FoodiesDbContext>
{
    public FoodiesDbContext CreateDbContext(string[] args)
    {
        const string connection = "Server=tcp:localhost,1433;Initial Catalog=Foodies;Persist Security Info=False;User ID=sa;Password=Tkm@akpRYh4m?qo4;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";

        return new FoodiesDbContext(connection);
    }
}
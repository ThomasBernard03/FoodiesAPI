using Bogus;
using Foodies.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Foodies.DataAccess;

public static class FakeDataSeeder
{
    public static void Seed(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetService<FoodiesDbContext>()!;

            context.Database.EnsureDeleted();

            context.Database.Migrate();

            var ingredients = new Faker<Ingredient>()
                .RuleFor(i => i.Name, f => f.Commerce.Product())
                .RuleFor(i => i.Picture, f => f.Image.PicsumUrl())
                .Generate(100);
            
            
            context.Set<Ingredient>().AddRange(ingredients);



            context.SaveChanges();
        }
    }
}
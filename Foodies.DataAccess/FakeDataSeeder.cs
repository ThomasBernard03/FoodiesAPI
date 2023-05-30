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
            
            var unitsOfMeasures = new List<UnitOfMeasure>
            {
                new UnitOfMeasure { Name = "Gramme" },
                new UnitOfMeasure { Name = "Kilogramme" },
                new UnitOfMeasure { Name = "Milligramme" },
                new UnitOfMeasure { Name = "Once" },
                new UnitOfMeasure { Name = "Livre" },
                new UnitOfMeasure { Name = "Quintal" },
                new UnitOfMeasure { Name = "Tasse" },
                new UnitOfMeasure { Name = "Cuillère à soupe" },
                new UnitOfMeasure { Name = "Cuillère à café" },
                new UnitOfMeasure { Name = "Litre" },
                new UnitOfMeasure { Name = "Millilitre" },
                new UnitOfMeasure { Name = "Pinte" },
                new UnitOfMeasure { Name = "Quart de gallon" },
                new UnitOfMeasure { Name = "Gallon" },
                new UnitOfMeasure { Name = "Pouce" },
                new UnitOfMeasure { Name = "Pied" },
                new UnitOfMeasure { Name = "Yard" },
                new UnitOfMeasure { Name = "Centimètre" },
                new UnitOfMeasure { Name = "Mètre" },
                new UnitOfMeasure { Name = "Kilomètre" },
                new UnitOfMeasure { Name = "Pied carré" },
                new UnitOfMeasure { Name = "Yard carré" },
                new UnitOfMeasure { Name = "Mètre carré" },
                new UnitOfMeasure { Name = "Acre" },
                new UnitOfMeasure { Name = "Hectare" },
            };
            
            context.Set<UnitOfMeasure>().AddRange(unitsOfMeasures);
            context.SaveChanges();


            var ingredients = new Faker<Ingredient>()
                .RuleFor(i => i.Name, f => f.Commerce.ProductName())
                .RuleFor(i => i.Picture, f => f.Image.PicsumUrl())
                .Generate(100);
            
            context.Set<Ingredient>().AddRange(ingredients);


            var recipes = new Faker<Recipe>()
                    .RuleFor(i => i.Name, f => f.Commerce.ProductName())
                    .RuleFor(i => i.Picture, f => f.Image.PicsumUrl())
                    .RuleFor(i => i.Duration, f => TimeSpan.FromMinutes(f.Random.Int(1, 360)))
                    .Generate(50);

            context.Set<Recipe>().AddRange(recipes);

            
            context.SaveChanges();
        }
    }
}
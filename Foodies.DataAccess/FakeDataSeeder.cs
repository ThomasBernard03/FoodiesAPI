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
                new() { Name = "Centiliters" },
                new() { Name = "Unit" }, 
                new() { Name = "cloves" },
                
            };
            
            context.Set<UnitOfMeasure>().AddRange(unitsOfMeasures);

            var ingredients = new List<Ingredient>
            {
                new (){ Name = "Olive oil", Picture = "https://assets.afcdn.com/recipe/20220114/127365_w120h120c1cx411cy411cxb822cyb822.webp"},
                new (){ Name = "Thyme", Picture = "https://assets.afcdn.com/recipe/20170607/67735_w120h120c1cx350cy350.webp"},
                new (){ Name = "Pepper", Picture = "https://assets.afcdn.com/recipe/20170607/67563_w120h120c1cx350cy350.webp"},
                new (){ Name = "Salt", Picture = "https://assets.afcdn.com/recipe/20170607/67687_w120h120c1cx350cy350.webp"},
                new (){ Name = "Chili pepper", Picture = "https://assets.afcdn.com/recipe/20170607/67581_w120h120c1cx261cy261.webp"},
                new (){ Name = "Artichokes", Picture = "https://assets.afcdn.com/recipe/20170607/67701_w120h120c1cx350cy350.webp"},
                new (){ Name = "Lemons", Picture = "https://assets.afcdn.com/recipe/20170607/67457_w120h120c1cx350cy350.webp"},
                new (){ Name = "Garlic", Picture = "https://assets.afcdn.com/recipe/20170607/67514_w120h120c1cx350cy350.webp"},
                new (){ Name = "Penne", Picture = "https://assets.afcdn.com/recipe/20170607/67468_w120h120c1cx350cy350.webp"},
                new (){ Name = "White wine", Picture = "https://assets.afcdn.com/recipe/20170607/67771_w120h120c1cx350cy350.webp"},
            };

            context.Set<Ingredient>().AddRange(ingredients);

            var users = new List<User>
            {
                new(){ AuthId = "b7d03a684f733568334f1e0253ed0584ef1f2ddf994a5dbcb05e6a791207a030", AuthProvider = "mock" }
            };
            
            context.Set<User>().AddRange(users);


            var recipe = new Recipe
            {
                Duration = TimeSpan.FromMinutes(40), Name = "Pasta with artichokes and peppers",
                Picture = "https://assets.afcdn.com/recipe/20160926/64114_w640h486c1cx1872cy2808.webp",
                Creator = users.First() 
            };

            context.Set<Recipe>().Add(recipe);
            context.SaveChanges();

            var steps = new List<Step>
            {
                new()
                {
                    Description =
                        "Clean artichokes so that only the most tender leaves remain. To do this, first remove all the first leaves, then cut off the top of the artichoke to remove the hard part of the remaining leaves. It's a lot of waste, but that's the way to do it!",
                    Number = 1,
                    Recipe = recipe
                },
                new ()
                {
                    Description = "Cut the artichokes into quarters and sprinkle with the juice of one lemon.",
                    Number = 2,
                    Recipe = recipe

                },
                new ()
                {
                    Description = "Heat the olive oil in a sauté pan, add the artichokes and sauté for about 5 minutes. Add the garlic in small pieces (or chopped if preferred), white wine, lemon juice, thyme sprig, salt, pepper and a pinch of hot pepper.",
                    Number = 3,
                    Recipe = recipe

                },
                new ()
                {
                    Description = "Cook over medium heat for 20-30 min, until artichokes are melting. If necessary, add a little water if the liquid decreases too much.",
                    Number = 4,
                    Recipe = recipe

                },
                new ()
                {
                    Description = "Meanwhile, boil the pasta (penne or other) and drain.",
                    Number = 5,
                    Recipe = recipe

                },
                new ()
                {
                    Description = "Combine pasta and artichokes and serve drizzled with olive oil.",
                    Number = 6,
                    Recipe = recipe
                }
            };
            
            context.SaveChanges();

            var stepIngredients = new List<StepIngredient>
            {
                new()
                {
                    Ingredient = ingredients.First(x => x.Name == "Artichokes"),
                    Quantity = 10,
                    Step = steps.First(),
                    UnitOfMeasure = unitsOfMeasures.First(x => x.Name == "Unit")
                },
                new()
                {
                    Ingredient = ingredients.First(x => x.Name == "Lemons"),
                    Quantity = 2,
                    Step = steps.Skip(1).First(),
                    UnitOfMeasure = unitsOfMeasures.First(x => x.Name == "Unit")
                },
                new()
                {
                    Ingredient = ingredients.First(x => x.Name == "Artichokes"),
                    Quantity = 1,
                    Step = steps.Skip(1).First(),
                    UnitOfMeasure = unitsOfMeasures.First(x => x.Name == "Unit")
                },
            };
            
            context.Set<StepIngredient>().AddRange(stepIngredients);


            var apiKey = new List<ApiKey>
            {
                new(){ Value = "b7d03a684f733568334f1e0253ed0584ef1f2ddf994a5dbcb05e6a791207a030"}
            };

            context.Set<ApiKey>().AddRange(apiKey);

            
            context.SaveChanges();
        }
    }
}
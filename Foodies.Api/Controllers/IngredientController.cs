using Foodies.DataAccess;
using Foodies.Domain;
using Foodies.Models.Responses.Ingredients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Foodies.Controllers;

[ApiController]
[Route("ingredients")]
public class IngredientController : ControllerBase
{
    private readonly FoodiesDbContext _context;

    public IngredientController(FoodiesDbContext context)
    {
        _context = context;
    }



    #region GET ingredients

    [HttpGet]
    public async Task<IEnumerable<Ingredient>> GetAllIngredients()
    {
        var ingredients = await _context.Set<Ingredient>().ToArrayAsync();

        return ingredients;
    }

    #endregion
}
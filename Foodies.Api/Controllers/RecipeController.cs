using AutoMapper;
using Foodies.DataAccess;
using Foodies.Domain;
using Foodies.Models.Responses.Recipe;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Foodies.Controllers;

[ApiController]
[Route("recipes")]
public class RecipeController : ControllerBase
{
    private readonly FoodiesDbContext _context;
    private readonly IMapper _mapper;

    public RecipeController(FoodiesDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    #region GET recipes

    [HttpGet]
    public async Task<IEnumerable<RecipeResponse>> GetRecipes()
    {
        var recipes = await _context.Set<Recipe>().ToArrayAsync();

        return _mapper.Map<IEnumerable<RecipeResponse>>(recipes);
    }

    #endregion
}
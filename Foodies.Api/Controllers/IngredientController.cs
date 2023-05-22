using AutoMapper;
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
    private readonly IMapper _mapper;

    public IngredientController(FoodiesDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    #region GET ingredients

    [HttpGet]
    public async Task<IEnumerable<IngredientResponse>> GetIngredients()
    {
        var ingredients = await _context.Set<Ingredient>().ToArrayAsync();

        return _mapper.Map<IEnumerable<IngredientResponse>>(ingredients);
    }

    #endregion
    
    #region GET ingredients/{id}

    [HttpGet("{id}")]
    public async Task<ActionResult<IngredientResponse>> GetIngredients([FromRoute] long id)
    {
        var ingredient = await _context.Set<Ingredient>().FirstOrDefaultAsync(i => i.Id == id);

        if (ingredient is null)
            return NotFound();

        return _mapper.Map<IngredientResponse>(ingredient);
    }

    #endregion
}
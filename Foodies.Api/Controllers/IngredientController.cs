using AutoMapper;
using Foodies.DataAccess;
using Foodies.Domain;
using Foodies.Models.Requests.Ingredients;
using Foodies.Models.Responses.Ingredients;
using Microsoft.AspNetCore.JsonPatch;
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

    #region POST ingredients

    [HttpPost]
    public async Task<ActionResult<IngredientResponse>> CreateIngredients([FromBody] IngredientRequest request)
    {
        var ingredient = _mapper.Map<Ingredient>(request);

        await _context.Set<Ingredient>().AddAsync(ingredient);
        await _context.SaveChangesAsync();
        
        return _mapper.Map<IngredientResponse>(ingredient);
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
    
    #region DELETE ingredients/{id}

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteIngredients([FromRoute] long id)
    {
        var ingredient = await _context.Set<Ingredient>().FirstOrDefaultAsync(i => i.Id == id);

        if (ingredient is null)
            return NotFound($"Ingredient with id {id} doesn't exist");

        _context.Set<Ingredient>().Remove(ingredient);
        await _context.SaveChangesAsync();

        return Ok();
    }

    #endregion

    #region PATCH ingredients/{id}

    [HttpPatch("{id}")]
    public async Task<ActionResult<IngredientResponse>> UpdateIngredients([FromRoute] long id, [FromBody] JsonPatchDocument<IngredientRequest> request)
    {
        var ingredient = await _context.Set<Ingredient>().FirstOrDefaultAsync(i => i.Id == id);

        if (ingredient is null)
            return NotFound($"Ingredient with id {id} doesn't exist");

        var updateCommand = _mapper.Map<IngredientRequest>(ingredient);
        
        request.ApplyTo(updateCommand);

        _mapper.Map(updateCommand, ingredient);

        _context.Update(ingredient);

        return _mapper.Map<IngredientResponse>(ingredient);
    }

    #endregion
}
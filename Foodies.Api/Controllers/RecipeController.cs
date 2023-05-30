using AutoMapper;
using Foodies.DataAccess;
using Foodies.Domain;
using Foodies.Models.Requests.Recipe;
using Foodies.Models.Requests.Step;
using Foodies.Models.Responses.Recipe;
using Foodies.Models.Responses.Step;
using Microsoft.AspNetCore.JsonPatch;
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
    
    #region POST recipes

    [HttpPost]
    public async Task<ActionResult<RecipeResponse>> CreateRecipes([FromBody] RecipeRequest request)
    {
        var recipe = _mapper.Map<Recipe>(request);

        await _context.Set<Recipe>().AddAsync(recipe);
        await _context.SaveChangesAsync();
        
        return _mapper.Map<RecipeResponse>(recipe);
    }

    #endregion


    #region GET recipes/{id}

    [HttpGet("{id}")]
    public async Task<ActionResult<RecipeResponse>> GetRecipes([FromRoute] long id)
    {
        var recipe = await _context.Set<Recipe>().FirstOrDefaultAsync(i => i.Id == id);

        if (recipe is null)
            return NotFound();

        return _mapper.Map<RecipeResponse>(recipe);
    }

    #endregion
    
    #region DELETE recipes/{id}

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteRecipes([FromRoute] long id)
    {
        var recipe = await _context.Set<Recipe>().FirstOrDefaultAsync(i => i.Id == id);

        if (recipe is null)
            return NotFound($"Recipe with id {id} doesn't exist");

        _context.Set<Recipe>().Remove(recipe);
        await _context.SaveChangesAsync();

        return Ok();
    }

    #endregion
    
    #region PATCH recipes/{id}

    [HttpPatch("{id}")]
    public async Task<ActionResult<RecipeResponse>> UpdateIngredients([FromRoute] long id, [FromBody] JsonPatchDocument<RecipeRequest> request)
    {
        var recipe = await _context.Set<Recipe>().FirstOrDefaultAsync(i => i.Id == id);

        if (recipe is null)
            return NotFound($"Recipe with id {id} doesn't exist");

        var updateCommand = _mapper.Map<RecipeRequest>(recipe);
        
        request.ApplyTo(updateCommand);

        _mapper.Map(updateCommand, recipe);

        _context.Update(recipe);

        return _mapper.Map<RecipeResponse>(recipe);
    }

    #endregion
    

    #region GET recipes/{id}/steps

    [HttpGet("{id}/steps")]
    public async Task<ActionResult<IEnumerable<StepResponse>>> GetRecipesSteps([FromRoute] long id)
    {
        var recipe = await _context.Set<Recipe>().FirstOrDefaultAsync(r => r.Id == id);
        
        if (recipe is null)
            return NotFound($"The recipe with id {id} doesn't exist");
        
        var steps = await _context.Set<Step>().Where(s => s.RecipeId == id).ToArrayAsync();

        return _mapper.Map<IEnumerable<StepResponse>>(steps).ToList();
    }

    #endregion
    
    #region POST recipes/{id}/steps

    [HttpPost("{id}/steps")]
    public async Task<ActionResult<StepResponse>> CreateRecipesSteps([FromRoute] long id, [FromBody] StepRequest request)
    {
        var recipe = await _context.Set<Recipe>().FirstOrDefaultAsync(r => r.Id == id);
        
        if (recipe is null)
            return NotFound($"The recipe with id {id} doesn't exist");

        var step = _mapper.Map<Step>(request);
        step.RecipeId = id;

        await _context.Set<Step>().AddAsync(step);
        await _context.SaveChangesAsync();
        
        return _mapper.Map<StepResponse>(step);
    }

    #endregion
}
using AutoMapper;
using Foodies.Domain;
using Foodies.Models.Requests.Recipe;
using Foodies.Models.Responses.Recipe;

namespace Foodies.Mapping;

public class RecipeProfile : Profile
{
    public RecipeProfile()
    {
        // Recipe => RecipeResponse
        CreateMap<Recipe, RecipeResponse>();
        
        // RecipeRequest => Recipe
        CreateMap<RecipeRequest, Recipe>()
            .ReverseMap();
    }
}
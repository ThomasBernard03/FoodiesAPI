using AutoMapper;
using Foodies.Domain;
using Foodies.Models.Responses.Ingredients;

namespace Foodies.Mapping;

public class IngredientProfile : Profile
{
    public IngredientProfile()
    {
        // Ingredient => IngredientResponse
        CreateMap<Ingredient, IngredientResponse>();
    }
}
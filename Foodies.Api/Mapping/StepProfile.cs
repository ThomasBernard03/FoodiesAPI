using AutoMapper;
using Foodies.Domain;
using Foodies.Models.Requests.Step;
using Foodies.Models.Responses.Step;

namespace Foodies.Mapping;

public class StepProfile : Profile
{
    public StepProfile()
    {
        // Step => StepResponse
        CreateMap<Step, StepResponse>()
            .ForMember(
                dest => dest.Ingredients, 
                opt => opt
                    .MapFrom(src => src.StepIngredients.Select(si => new StepIngredientResponse
                    {
                        Name = si.Ingredient.Name,
                        Quantity = si.Quantity,
                        UnitOfMeasure = si.UnitOfMeasure.Name,
                        Picture = si.Ingredient.Picture
                    })));
        
        // StepRequest => Step
        CreateMap<StepRequest, Step>();
        
        // StepIngredient => StepIngredientResponse
        CreateMap<StepIngredient, StepIngredientResponse>();
    }
}
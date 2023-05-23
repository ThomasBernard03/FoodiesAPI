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
        CreateMap<Step, StepResponse>();
        
        // StepRequest => Step
        CreateMap<StepRequest, Step>();
    }
}
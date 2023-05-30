using Foodies.Domain.Base;

namespace Foodies.Domain;

public class UnitOfMeasure : BaseEntity
{
    public string Name { get; set; } = "";
    
    public ICollection<StepIngredient> StepIngredients { get; set; }
}
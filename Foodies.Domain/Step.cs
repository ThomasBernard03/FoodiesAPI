using Foodies.Domain.Base;

namespace Foodies.Domain;

public class Step : BaseEntity
{
    public int Number { get; set; }
    
    public long RecipeId { get; set; }
    public Recipe Recipe { get; set; }
    
    public ICollection<StepIngredient> StepIngredients { get; set; }
}
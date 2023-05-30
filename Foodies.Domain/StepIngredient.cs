namespace Foodies.Domain;

public class StepIngredient
{
    public long StepId { get; set; }
    public Step Step { get; set; }
    
    public long IngredientId { get; set; }
    public Ingredient Ingredient { get; set; }
    
    public long UnitOfMeasureId { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }

    public double Quantity { get; set; }
}
namespace Foodies.Models.Responses.Step;

public class StepIngredientResponse
{
    public string Name { get; set; } = "";
    public string Picture { get; set; } = "";
    public double Quantity { get; set; }
    public string UnitOfMeasure { get; set; } = "";
}
namespace Foodies.Models.Responses.Step;

public class StepResponse
{
    public long Id { get; set; }
    public int Number { get; set; }
    public string Description { get; set; } = "";

    public IEnumerable<StepIngredientResponse>? Ingredients { get; set; } = null;
}
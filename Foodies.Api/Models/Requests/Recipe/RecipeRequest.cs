namespace Foodies.Models.Requests.Recipe;

public class RecipeRequest
{
    public string Name { get; set; } = "";
    public string Picture { get; set; } = "";
    public long UnitOfMeasureId { get; set; }
}
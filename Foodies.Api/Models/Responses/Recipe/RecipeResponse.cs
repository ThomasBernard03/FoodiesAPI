namespace Foodies.Models.Responses.Recipe;

public class RecipeResponse
{
    public long Id { get; set; }
    public string Name { get; set; } = "";
    public string Picture { get; set; } = "";
    public TimeSpan Duration { get; set; }
}
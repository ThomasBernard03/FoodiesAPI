using System.ComponentModel.DataAnnotations;

namespace Foodies.Models.Requests.Recipe;

public class RecipeRequest
{
    [Required]
    public string Name { get; set; } = "";
    
    [Required]
    public string Picture { get; set; } = "";
    
    [Required]
    public TimeSpan Duration { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace Foodies.Models.Requests.Ingredients;

public class IngredientRequest
{
    [Required]
    public string Name { get; set; } = "";
    
    [Required]
    public string Picture { get; set; } = "";
    
    [Required]
    public long UnitOfMeasureId { get; set; }
}
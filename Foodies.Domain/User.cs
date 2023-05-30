using Foodies.Domain.Base;

namespace Foodies.Domain;

public class User : BaseEntity
{
    public string AuthProvider { get; set; } = "";
    public string AuthId { get; set; } = "";
    
    public ICollection<Recipe> Recipes { get; set; }

}
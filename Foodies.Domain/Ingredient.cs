using Foodies.Domain.Base;

namespace Foodies.Domain;

public class Ingredient : BaseEntity
{
    public string Name { get; set; } = "";
    public string Picture { get; set; } = "";
    
    public long UnitOfMeasureId { get; set; }
}
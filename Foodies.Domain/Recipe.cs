using Foodies.Domain.Base;

namespace Foodies.Domain;

public class Recipe : BaseEntity
{
    public string Name { get; set; } = "";
    public string Picture { get; set; } = "";
    public TimeSpan Duration { get; set; }


    public long CreatorId { get; set; }
    public User Creator { get; set; }
    public ICollection<Step> Steps { get; set; }
}
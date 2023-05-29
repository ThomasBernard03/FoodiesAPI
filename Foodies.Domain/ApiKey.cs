using Foodies.Domain.Base;

namespace Foodies.Domain;

public class ApiKey : BaseEntity
{
    public string Value { get; set; } = "";
}
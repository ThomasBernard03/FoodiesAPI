using Foodies.DataAccess.Configurations.Base;
using Foodies.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foodies.DataAccess.Configurations;

public class RecipeConfiguration : BaseEntityConfiguration<Recipe>
{
    public override void Configure(EntityTypeBuilder<Recipe> builder)
    {
        base.Configure(builder);

        builder
            .HasOne(r => r.Creator)
            .WithMany(u => u.Recipes)
            .HasForeignKey(r => r.CreatorId)
            .HasPrincipalKey(u => u.Id);
    }
}
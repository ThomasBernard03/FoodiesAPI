using Foodies.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foodies.DataAccess.Configurations;

public class StepIngredientConfiguration : IEntityTypeConfiguration<StepIngredient>
{
    public void Configure(EntityTypeBuilder<StepIngredient> builder)
    {
        builder.HasKey(e => new { e.StepId, e.IngredientId });
        
        builder
            .HasOne(e => e.Step)
            .WithMany(e => e.StepIngredients)
            .HasForeignKey(e => e.StepId)
            .HasPrincipalKey(e => e.Id);

        builder
            .HasOne(e => e.Ingredient)
            .WithMany(e => e.StepIngredients)
            .HasForeignKey(e => e.IngredientId)
            .HasPrincipalKey(e => e.Id);
        
        builder
            .HasOne(e => e.UnitOfMeasure)
            .WithMany(e => e.StepIngredients)
            .HasForeignKey(e => e.UnitOfMeasureId)
            .HasPrincipalKey(e => e.Id);
    }
}
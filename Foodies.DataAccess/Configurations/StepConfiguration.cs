using Foodies.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foodies.DataAccess.Configurations;

public abstract class StepConfiguration : IEntityTypeConfiguration<Step>
{
    public virtual void Configure(EntityTypeBuilder<Step> builder)
    {
        builder
            .HasOne(e => e.Recipe)
            .WithMany(e => e.Steps)
            .HasForeignKey(e => e.RecipeId)
            .HasPrincipalKey(e => e.Id);
    }
}
using Foodies.DataAccess.Configurations.Base;
using Foodies.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foodies.DataAccess.Configurations;

public class UserConfiguration : BaseEntityConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasIndex(u => new { u.AuthProvider, u.AuthId })
            .IsUnique();
    }
}
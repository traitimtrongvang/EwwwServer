using Application.Entities;
using Application.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EwwwDb.EntityConfig;

public class UserConfig : EntityBaseConfig<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasIndex(u => u.AuthId)
            .IsUnique();

        builder
            .Property(u => u.AuthId)
            .HasColumnType("varchar")
            .HasConversion(
                authId => (string)authId,
                authIdStr => new AuthId(authIdStr));
        
        base.Configure(builder);
    }
}
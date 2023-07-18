using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EwwwDb.EntityConfig;

public abstract class EntityBaseConfig<T> : IEntityTypeConfiguration<T> where T : EntityBase
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder
            .HasKey(e => e.Id);
        
        // builder
        //     .Property(e => e.CreatedAt)
        
        builder
            .Property(e => e.UpdatedAt)
            .ValueGeneratedOnAddOrUpdate();
    }
}
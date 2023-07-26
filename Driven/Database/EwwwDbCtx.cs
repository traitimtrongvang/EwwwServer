using Application.Contracts.Driven.EwwwDb;
using Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class EwwwDbCtx : DbContext, IEwwwDbCtx
{
    public DbSet<User> Users { get; set; } = null!;
    
    public EwwwDbCtx(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EwwwDbCtx).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}
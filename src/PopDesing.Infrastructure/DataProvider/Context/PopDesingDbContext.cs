using Microsoft.EntityFrameworkCore;
using PopDesing.Domain.Entities;

namespace PopDesing.Infrastructure.DataProvider.Context;

public class PopDesingDbContext: DbContext
{
    public PopDesingDbContext(DbContextOptions<PopDesingDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PopDesingDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public const string Schema = "dbo";

    public DbSet<Equipamento> Equipamentos { get; set; }
}

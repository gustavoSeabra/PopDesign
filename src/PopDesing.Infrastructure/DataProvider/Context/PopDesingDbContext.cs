﻿using Microsoft.EntityFrameworkCore;
using PopDesing.Domain.Entities;
using PopDesing.Domain.Repositories;

namespace PopDesing.Infrastructure.DataProvider.Context;

public class PopDesingDbContext: DbContext, IUnitOfWork
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

    public DbSet<Equipamento> Equipamentos { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<ProdutoComposicao> ProdutoComposicoes { get; set; }
}

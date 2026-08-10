using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PopLume.Domain.Entities;

namespace PopLume.Infrastructure.DataProvider.EntityConfigurations;

public class ProdutoVariacaoFilamentoEntityConfiguration : IEntityTypeConfiguration<ProdutoVariacaoFilamento>
{
    public void Configure(EntityTypeBuilder<ProdutoVariacaoFilamento> builder)
    {
        builder.ToTable("ProdutoVariacaoFilamento");
        builder.HasKey(x => x.IdProdutoVariacaoFilamento);
        builder.Property(x => x.QuantidadeGramas).HasPrecision(10, 3).IsRequired();
        builder.Property(x => x.PercentualPerda).HasPrecision(5, 2).IsRequired();
        builder.HasIndex(x => new { x.IdProdutoVariacao, x.IdFilamento }).IsUnique();
        builder.HasOne(x => x.ProdutoVariacao).WithMany(x => x.Filamentos)
            .HasForeignKey(x => x.IdProdutoVariacao).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Filamento).WithMany(x => x.Variacoes)
            .HasForeignKey(x => x.IdFilamento).OnDelete(DeleteBehavior.Restrict);
    }
}

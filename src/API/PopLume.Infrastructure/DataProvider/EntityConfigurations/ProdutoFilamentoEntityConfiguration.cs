using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PopLume.Domain.Entities;

namespace PopLume.Infrastructure.DataProvider.EntityConfigurations;

public class ProdutoFilamentoEntityConfiguration : IEntityTypeConfiguration<ProdutoFilamento>
{
    public void Configure(EntityTypeBuilder<ProdutoFilamento> builder)
    {
        builder.ToTable("ProdutoFilamento");
        builder.HasKey(x => x.IdProdutoFilamento);
        builder.Property(x => x.QuantidadeGramas).HasPrecision(10, 3).IsRequired();
        builder.Property(x => x.PercentualPerda).HasPrecision(5, 2).IsRequired();
        builder.HasIndex(x => new { x.IdProduto, x.IdFilamento }).IsUnique();
        builder.HasOne(x => x.Produto).WithMany(x => x.Filamentos)
            .HasForeignKey(x => x.IdProduto).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Filamento).WithMany(x => x.Produtos)
            .HasForeignKey(x => x.IdFilamento).OnDelete(DeleteBehavior.Restrict);
    }
}

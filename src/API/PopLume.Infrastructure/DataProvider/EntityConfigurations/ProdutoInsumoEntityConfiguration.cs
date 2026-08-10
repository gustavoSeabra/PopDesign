using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PopLume.Domain.Entities;

namespace PopLume.Infrastructure.DataProvider.EntityConfigurations;

public class ProdutoInsumoEntityConfiguration : IEntityTypeConfiguration<ProdutoInsumo>
{
    public void Configure(EntityTypeBuilder<ProdutoInsumo> builder)
    {
        builder.ToTable("ProdutoInsumo");
        builder.HasKey(x => x.IdProdutoInsumo);
        builder.Property(x => x.QuantidadeUtilizada).HasPrecision(12, 4).IsRequired();
        builder.HasIndex(x => new { x.IdProduto, x.IdInsumo }).IsUnique();
        builder.HasOne(x => x.Produto).WithMany(x => x.Insumos)
            .HasForeignKey(x => x.IdProduto).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Insumo).WithMany(x => x.Produtos)
            .HasForeignKey(x => x.IdInsumo).OnDelete(DeleteBehavior.Restrict);
    }
}

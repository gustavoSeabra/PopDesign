using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PopLume.Domain.Entities;

namespace PopLume.Infrastructure.DataProvider.EntityConfigurations;

public class ProdutoVariacaoEntityConfiguration : IEntityTypeConfiguration<ProdutoVariacao>
{
    public void Configure(EntityTypeBuilder<ProdutoVariacao> builder)
    {
        builder.ToTable("ProdutoVariacao");
        builder.HasKey(x => x.IdProdutoVariacao);
        builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();
        builder.Property(x => x.CodigoInterno).HasMaxLength(50);
        builder.Property(x => x.Ativa).HasDefaultValue(true).IsRequired();
        builder.Property(x => x.PrecoCusto).HasPrecision(10, 2).IsRequired();
        builder.HasIndex(x => new { x.IdProduto, x.Nome }).IsUnique();
        builder.HasOne(x => x.Produto).WithMany(x => x.Variacoes)
            .HasForeignKey(x => x.IdProduto).OnDelete(DeleteBehavior.Cascade);
    }
}

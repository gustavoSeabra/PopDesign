using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PopLume.Domain.Entities;

namespace PopLume.Infrastructure.DataProvider.EntityConfigurations;

public class FichaPrecificacaoEntityConfiguration : IEntityTypeConfiguration<FichaPrecificacao>
{
    public void Configure(EntityTypeBuilder<FichaPrecificacao> builder)
    {
        builder.ToTable("FichaPrecificacao");
        builder.HasKey(x => x.IdFichaPrecificacao);
        builder.Property(x => x.MargemPercentual).HasPrecision(5, 2);
        builder.Property(x => x.ComissaoPercentual).HasPrecision(5, 2);
        builder.Property(x => x.TaxaFixa).HasPrecision(10, 2);
        builder.Property(x => x.CustoFilamentos).HasPrecision(14, 4);
        builder.Property(x => x.CustoInsumos).HasPrecision(14, 4);
        builder.Property(x => x.CustoComponentes).HasPrecision(14, 4);
        builder.Property(x => x.CustoEnergia).HasPrecision(14, 4);
        builder.Property(x => x.CustoEquipamento).HasPrecision(14, 4);
        builder.Property(x => x.CustoMaoDeObra).HasPrecision(14, 4);
        builder.Property(x => x.CustoTotalLote).HasPrecision(14, 4);
        builder.Property(x => x.CustoUnitario).HasPrecision(14, 4);
        builder.Property(x => x.ValorComissao).HasPrecision(14, 4);
        builder.Property(x => x.LucroUnitario).HasPrecision(14, 4);
        builder.Property(x => x.PrecoVenda).HasPrecision(10, 2);
        builder.HasIndex(x => new { x.IdProduto, x.CalculadaEmUtc });
        builder.HasOne(x => x.Produto).WithMany(x => x.FichasPrecificacao)
            .HasForeignKey(x => x.IdProduto).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Equipamento).WithMany()
            .HasForeignKey(x => x.IdEquipamento).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.TarifaEnergia).WithMany()
            .HasForeignKey(x => x.IdTarifaEnergia).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.ConfiguracaoMaoDeObra).WithMany()
            .HasForeignKey(x => x.IdCustoMaoDeObra).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Marketplace).WithMany()
            .HasForeignKey(x => x.IdMarketplace).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.TaxaMarketplace).WithMany()
            .HasForeignKey(x => x.IdTaxaMarketplace).OnDelete(DeleteBehavior.Restrict);
    }
}

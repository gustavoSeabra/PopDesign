using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PopLume.Domain.Entities;

namespace PopLume.Infrastructure.DataProvider.EntityConfigurations;

public class TarifaEnergiaEntityConfiguration : IEntityTypeConfiguration<TarifaEnergia>
{
    public void Configure(EntityTypeBuilder<TarifaEnergia> builder)
    {
        builder.ToTable("TarifaEnergia");
        builder.HasKey(x => x.IdTarifaEnergia);
        builder.Property(x => x.ValorKwh).HasPrecision(10, 4).IsRequired();
        builder.Property(x => x.InicioVigencia).HasColumnType("date").IsRequired();
        builder.Property(x => x.FimVigencia).HasColumnType("date");
        builder.HasIndex(x => x.InicioVigencia);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PopLume.Domain.Entities;
using PopLume.Domain.Enums;

namespace PopLume.Infrastructure.DataProvider.EntityConfigurations;

public class InsumoEntityConfiguration : IEntityTypeConfiguration<Insumo>
{
    public void Configure(EntityTypeBuilder<Insumo> builder)
    {
        builder.ToTable("Insumo");
        builder.HasKey(x => x.IdInsumo);
        builder.HasQueryFilter(x => !x.Excluido);
        builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
        builder.Property(x => x.ValorCompra).HasPrecision(10, 2).IsRequired();
        builder.Property(x => x.QuantidadeComprada).HasPrecision(12, 4).IsRequired();
        builder.Property(x => x.UnidadeMedida)
            .HasConversion(new EnumToStringConverter<UnidadeMedida>())
            .HasMaxLength(20).IsRequired();
        builder.Property(x => x.Excluido).HasDefaultValue(false).IsRequired();
    }
}

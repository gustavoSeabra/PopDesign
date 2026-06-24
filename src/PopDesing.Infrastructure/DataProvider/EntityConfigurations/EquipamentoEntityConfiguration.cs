using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PopDesing.Domain.Entities;

namespace PopDesing.Infrastructure.DataProvider.EntityConfigurations;

public class EquipamentoEntityConfiguration : IEntityTypeConfiguration<Equipamento>
{
    public void Configure(EntityTypeBuilder<Equipamento> builder)
    {
        builder.ToTable("Equipamento");
        builder.HasKey(e => e.IdEquipamento);
        builder.HasQueryFilter(e => !e.Excluido);

        builder.Property(e => e.Nome).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Apelido).HasMaxLength(50);
        builder.Property(e => e.DataCompra).IsRequired();
        builder.Property(e => e.Potencia).IsRequired();
        builder.Property(e => e.ValorCompra);
        builder.Property(e => e.ExpectativaVida);
        builder.Property(e => e.Excluido).IsRequired().HasDefaultValue(false);
        builder.Property(e => e.DataExclusao);
    }
}

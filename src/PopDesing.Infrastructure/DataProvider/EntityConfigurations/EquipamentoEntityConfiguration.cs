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
        builder.Property(e => e.Nome).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Apelido).HasMaxLength(50);
        builder.Property(e => e.Potencia).IsRequired();
    }
}

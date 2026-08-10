using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PopLume.Domain.Entities;

namespace PopLume.Infrastructure.DataProvider.EntityConfigurations;

public class CustoMaoDeObraEntityConfiguration : IEntityTypeConfiguration<CustoMaoDeObra>
{
    public void Configure(EntityTypeBuilder<CustoMaoDeObra> builder)
    {
        builder.ToTable("CustoMaoDeObra");
        builder.HasKey(x => x.IdCustoMaoDeObra);
        builder.Property(x => x.ValorHora).HasPrecision(10, 2).IsRequired();
        builder.Property(x => x.InicioVigencia).HasColumnType("date").IsRequired();
        builder.Property(x => x.FimVigencia).HasColumnType("date");
        builder.HasIndex(x => x.InicioVigencia);
    }
}

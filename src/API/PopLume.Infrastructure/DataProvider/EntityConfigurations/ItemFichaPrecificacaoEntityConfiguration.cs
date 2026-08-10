using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PopLume.Domain.Entities;
using PopLume.Domain.Enums;

namespace PopLume.Infrastructure.DataProvider.EntityConfigurations;

public class ItemFichaPrecificacaoEntityConfiguration : IEntityTypeConfiguration<ItemFichaPrecificacao>
{
    public void Configure(EntityTypeBuilder<ItemFichaPrecificacao> builder)
    {
        builder.ToTable("ItemFichaPrecificacao");
        builder.HasKey(x => x.IdItemFichaPrecificacao);
        builder.Property(x => x.Tipo).HasConversion(new EnumToStringConverter<TipoItemPrecificacao>()).HasMaxLength(30);
        builder.Property(x => x.Descricao).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Quantidade).HasPrecision(14, 4);
        builder.Property(x => x.ValorUnitario).HasPrecision(14, 4);
        builder.Property(x => x.ValorTotal).HasPrecision(14, 4);
        builder.HasOne(x => x.FichaPrecificacao).WithMany(x => x.Itens)
            .HasForeignKey(x => x.IdFichaPrecificacao).OnDelete(DeleteBehavior.Cascade);
    }
}

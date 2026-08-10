using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PopLume.Domain.Entities;

namespace PopLume.Infrastructure.DataProvider.EntityConfigurations;

public class ProdutoEntityConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produto");
        builder.HasKey(e => e.IdProduto);
        
        builder.Property(e => e.Nome).IsRequired().HasMaxLength(100);
        builder.Property(e => e.TempoImpressaoMinutos);
        builder.Property(e => e.TempoMaoDeObraMinutos);

        builder.HasOne(e => e.Equipamento)
            .WithMany()
            .HasForeignKey(e => e.IdEquipamento)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

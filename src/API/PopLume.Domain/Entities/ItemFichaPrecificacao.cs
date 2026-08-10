using PopLume.Domain.Enums;

namespace PopLume.Domain.Entities;

public class ItemFichaPrecificacao
{
    public Guid IdItemFichaPrecificacao { get; set; }
    public Guid IdFichaPrecificacao { get; set; }
    public TipoItemPrecificacao Tipo { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public decimal Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
    public decimal ValorTotal { get; set; }

    public virtual FichaPrecificacao FichaPrecificacao { get; set; } = null!;
}

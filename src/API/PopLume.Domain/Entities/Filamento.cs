using PopLume.Domain.Enums;

namespace PopLume.Domain.Entities;

public class Filamento
{
    public Guid IdFilamento { get; set; }
    public string Cor { get; set; } = string.Empty;
    public decimal ValorCompra { get; set; }
    public decimal PesoLiquidoGramas { get; set; }
    public TipoFilamento Tipo { get; set; }
    public DateOnly DataCompra { get; set; }

    public virtual ICollection<ProdutoVariacaoFilamento> Variacoes { get; set; } = new List<ProdutoVariacaoFilamento>();

    public decimal CalcularCustoPorGrama()
    {
        if (PesoLiquidoGramas <= 0)
            throw new InvalidOperationException("O peso líquido do filamento deve ser maior que zero.");

        return ValorCompra / PesoLiquidoGramas;
    }
}

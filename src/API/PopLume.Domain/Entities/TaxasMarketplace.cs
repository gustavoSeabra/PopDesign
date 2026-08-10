namespace PopLume.Domain.Entities;

public class TaxasMarketplace
{
    public Guid IdTaxa { get; set; }
    public Guid IdMarketplace { get; set; }
    public decimal ValorInicial { get; set; }
    public decimal? ValorFinal { get; set; }
    public decimal ComissaoPercentual { get; set; }
    public decimal TaxaFixa { get; set; }

    public virtual Marketplace Marketplace { get; set; } = null!;

    public bool TentarAtualizarValores(
        decimal valorInicial,
        decimal? valorFinal,
        decimal comissaoPercentual,
        decimal taxaFixa)
    {
        if (valorFinal.HasValue && valorFinal.Value < valorInicial)
            return false;

        ValorInicial = valorInicial;
        ValorFinal = valorFinal;
        ComissaoPercentual = comissaoPercentual;
        TaxaFixa = taxaFixa;

        return true;
    }

    public bool Contem(decimal preco) =>
        preco >= ValorInicial && (!ValorFinal.HasValue || preco <= ValorFinal.Value);
}

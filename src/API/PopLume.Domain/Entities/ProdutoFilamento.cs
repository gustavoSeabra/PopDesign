namespace PopLume.Domain.Entities;

public class ProdutoFilamento
{
    public Guid IdProdutoFilamento { get; set; }
    public Guid IdProduto { get; set; }
    public Guid IdFilamento { get; set; }
    public decimal QuantidadeGramas { get; set; }
    public decimal PercentualPerda { get; set; }

    public virtual Produto Produto { get; set; } = null!;
    public virtual Filamento Filamento { get; set; } = null!;

    public decimal CalcularQuantidadeComPerda()
    {
        if (QuantidadeGramas <= 0)
            throw new InvalidOperationException("A quantidade de filamento deve ser maior que zero.");
        if (PercentualPerda is < 0 or > 100)
            throw new InvalidOperationException("O percentual de perda deve estar entre 0 e 100.");

        return QuantidadeGramas * (1m + PercentualPerda / 100m);
    }

    public decimal CalcularCusto() => CalcularQuantidadeComPerda() * Filamento.CalcularCustoPorGrama();
}

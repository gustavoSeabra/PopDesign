namespace PopLume.Domain.Entities;

public class ProdutoVariacao
{
    public Guid IdProdutoVariacao { get; set; }
    public Guid IdProduto { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? CodigoInterno { get; set; }
    public bool Ativa { get; set; } = true;
    public decimal PrecoCusto { get; private set; }

    public virtual Produto Produto { get; set; } = null!;
    public virtual ICollection<ProdutoVariacaoFilamento> Filamentos { get; set; } = new List<ProdutoVariacaoFilamento>();
    public virtual ICollection<FichaPrecificacao> FichasPrecificacao { get; set; } = new List<FichaPrecificacao>();

    public void AtualizarPrecoCusto(decimal precoCusto)
    {
        if (precoCusto < 0)
            throw new ArgumentOutOfRangeException(nameof(precoCusto), "O preço de custo não pode ser negativo.");

        PrecoCusto = precoCusto;
    }
}

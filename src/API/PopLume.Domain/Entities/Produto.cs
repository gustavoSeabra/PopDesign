namespace PopLume.Domain.Entities;

public class Produto
{
    public Guid IdProduto { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal PrecoCusto { get; private set; }
    public int TempoImpressaoMinutos { get; set; }
    public int TempoMaoDeObraMinutos { get; set; }
    public Guid? IdEquipamento { get; set; }

    public virtual Equipamento? Equipamento { get; set; }
    public virtual ICollection<ProdutoFilamento> Filamentos { get; set; } = new List<ProdutoFilamento>();
    public virtual ICollection<ProdutoInsumo> Insumos { get; set; } = new List<ProdutoInsumo>();
    public virtual ICollection<FichaPrecificacao> FichasPrecificacao { get; set; } = new List<FichaPrecificacao>();

    // Propriedades de Navegação
    // Componentes que formam este produto
    public virtual ICollection<ProdutoComposicao> ComposicoesPai { get; set; } = new List<ProdutoComposicao>();
    // Onde este produto é usado como componente
    public virtual ICollection<ProdutoComposicao> ComposicoesFilho { get; set; } = new List<ProdutoComposicao>();

    public void AtualizarPrecoCusto(decimal precoCusto)
    {
        if (precoCusto < 0)
            throw new ArgumentOutOfRangeException(nameof(precoCusto), "O preço de custo não pode ser negativo.");

        PrecoCusto = precoCusto;
    }
}

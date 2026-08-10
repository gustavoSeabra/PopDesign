namespace PopLume.Domain.Entities;

public class Produto
{
    public Guid IdProduto { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int TempoImpressaoMinutos { get; set; }
    public int TempoMaoDeObraMinutos { get; set; }
    public Guid? IdEquipamento { get; set; }

    public virtual Equipamento? Equipamento { get; set; }
    public virtual ICollection<ProdutoVariacao> Variacoes { get; set; } = new List<ProdutoVariacao>();
    public virtual ICollection<ProdutoInsumo> Insumos { get; set; } = new List<ProdutoInsumo>();
    public virtual ICollection<FichaPrecificacao> FichasPrecificacao { get; set; } = new List<FichaPrecificacao>();

    // Propriedades de Navegação
    // Componentes que formam este produto
    public virtual ICollection<ProdutoComposicao> ComposicoesPai { get; set; } = new List<ProdutoComposicao>();
    // Onde este produto é usado como componente
    public virtual ICollection<ProdutoComposicao> ComposicoesFilho { get; set; } = new List<ProdutoComposicao>();

}

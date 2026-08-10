namespace PopLume.Domain.Entities;

public class FichaPrecificacao
{
    public Guid IdFichaPrecificacao { get; set; }
    public Guid IdProduto { get; set; }
    public Guid IdEquipamento { get; set; }
    public Guid IdTarifaEnergia { get; set; }
    public Guid IdCustoMaoDeObra { get; set; }
    public Guid? IdMarketplace { get; set; }
    public Guid? IdTaxaMarketplace { get; set; }
    public DateTime CalculadaEmUtc { get; set; }
    public int QuantidadeProduzida { get; set; }
    public decimal MargemPercentual { get; set; }
    public decimal ComissaoPercentual { get; set; }
    public decimal TaxaFixa { get; set; }
    public decimal CustoFilamentos { get; set; }
    public decimal CustoInsumos { get; set; }
    public decimal CustoComponentes { get; set; }
    public decimal CustoEnergia { get; set; }
    public decimal CustoEquipamento { get; set; }
    public decimal CustoMaoDeObra { get; set; }
    public decimal CustoTotalLote { get; set; }
    public decimal CustoUnitario { get; set; }
    public decimal ValorComissao { get; set; }
    public decimal LucroUnitario { get; set; }
    public decimal PrecoVenda { get; set; }

    public virtual Produto Produto { get; set; } = null!;
    public virtual Equipamento Equipamento { get; set; } = null!;
    public virtual TarifaEnergia TarifaEnergia { get; set; } = null!;
    public virtual CustoMaoDeObra ConfiguracaoMaoDeObra { get; set; } = null!;
    public virtual Marketplace? Marketplace { get; set; }
    public virtual TaxasMarketplace? TaxaMarketplace { get; set; }
    public virtual ICollection<ItemFichaPrecificacao> Itens { get; set; } = new List<ItemFichaPrecificacao>();
}

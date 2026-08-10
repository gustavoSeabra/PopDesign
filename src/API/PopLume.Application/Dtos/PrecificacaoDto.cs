namespace PopLume.Application.Dtos;

public class CalcularPrecificacaoDto
{
    public Guid IdEquipamento { get; set; }
    public Guid? IdMarketplace { get; set; }
    public decimal MargemPercentual { get; set; }
    public int QuantidadeProduzida { get; set; } = 1;
}

public class PrecificacaoDto
{
    public Guid? IdFichaPrecificacao { get; set; }
    public Guid IdProduto { get; set; }
    public DateTime? CalculadaEmUtc { get; set; }
    public decimal CustoFilamentos { get; set; }
    public decimal CustoInsumos { get; set; }
    public decimal CustoComponentes { get; set; }
    public decimal CustoEnergia { get; set; }
    public decimal CustoEquipamento { get; set; }
    public decimal CustoMaoDeObra { get; set; }
    public decimal CustoTotalLote { get; set; }
    public decimal CustoUnitario { get; set; }
    public decimal ValorComissao { get; set; }
    public decimal TaxaFixa { get; set; }
    public decimal LucroUnitario { get; set; }
    public decimal PrecoVenda { get; set; }
}

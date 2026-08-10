namespace PopLume.Domain.Entities;

public class ProdutoInsumo
{
    public Guid IdProdutoInsumo { get; set; }
    public Guid IdProduto { get; set; }
    public Guid IdInsumo { get; set; }
    public decimal QuantidadeUtilizada { get; set; }

    public virtual Produto Produto { get; set; } = null!;
    public virtual Insumo Insumo { get; set; } = null!;

    public decimal CalcularCusto()
    {
        if (QuantidadeUtilizada <= 0)
            throw new InvalidOperationException("A quantidade utilizada deve ser maior que zero.");

        return QuantidadeUtilizada * Insumo.CalcularCustoUnitario();
    }
}

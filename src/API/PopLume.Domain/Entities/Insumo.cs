using PopLume.Domain.Enums;

namespace PopLume.Domain.Entities;

public class Insumo
{
    public Guid IdInsumo { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal ValorCompra { get; set; }
    public decimal QuantidadeComprada { get; set; }
    public UnidadeMedida UnidadeMedida { get; set; }
    public bool Excluido { get; private set; }
    public DateTime? DataExclusao { get; private set; }

    public virtual ICollection<ProdutoInsumo> Produtos { get; set; } = new List<ProdutoInsumo>();

    public decimal CalcularCustoUnitario()
    {
        if (QuantidadeComprada <= 0)
            throw new InvalidOperationException("A quantidade comprada deve ser maior que zero.");

        return ValorCompra / QuantidadeComprada;
    }

    public void Excluir()
    {
        Excluido = true;
        DataExclusao = DateTime.UtcNow;
    }

    public void Restaurar()
    {
        Excluido = false;
        DataExclusao = null;
    }
}

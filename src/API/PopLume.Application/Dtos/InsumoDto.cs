using PopLume.Domain.Enums;

namespace PopLume.Application.Dtos;

public class InsumoDto
{
    public Guid IdInsumo { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal ValorCompra { get; set; }
    public decimal QuantidadeComprada { get; set; }
    public UnidadeMedida UnidadeMedida { get; set; }
    public decimal CustoUnitario { get; set; }
}

public class CreateInsumoDto
{
    public string Nome { get; set; } = string.Empty;
    public decimal? ValorCompra { get; set; }
    public decimal? QuantidadeComprada { get; set; }
    public UnidadeMedida? UnidadeMedida { get; set; }
}

public class UpdateInsumoDto : CreateInsumoDto
{
    public Guid IdInsumo { get; set; }
}

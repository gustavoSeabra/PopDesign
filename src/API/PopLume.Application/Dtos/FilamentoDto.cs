using PopLume.Domain.Enums;

namespace PopLume.Application.Dtos;

public class FilamentoDto
{
    public Guid IdFilamento { get; set; }
    public string Cor { get; set; } = string.Empty;
    public decimal ValorCompra { get; set; }
    public decimal PesoLiquidoGramas { get; set; }
    public TipoFilamento Tipo { get; set; }
    public DateOnly DataCompra { get; set; }
}

public class CreateFilamentoDto
{
    public string Cor { get; set; } = string.Empty;
    public decimal? ValorCompra { get; set; }
    public decimal? PesoLiquidoGramas { get; set; }
    public TipoFilamento? Tipo { get; set; }
    public DateOnly? DataCompra { get; set; }
}

public class UpdateFilamentoDto
{
    public Guid IdFilamento { get; set; }
    public string Cor { get; set; } = string.Empty;
    public decimal? ValorCompra { get; set; }
    public decimal? PesoLiquidoGramas { get; set; }
    public TipoFilamento? Tipo { get; set; }
    public DateOnly? DataCompra { get; set; }
}

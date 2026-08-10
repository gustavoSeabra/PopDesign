namespace PopLume.Application.Dtos;

public class EquipamentoDto
{
    public Guid IdEquipamento { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Apelido { get; set; } = string.Empty;
    public DateOnly DataCompra { get; set; }
    public int PotenciaWatts { get; set; }
    public decimal ValorCompra { get; set; }
    public int VidaUtilHoras { get; set; }
    public decimal CustoDepreciacaoHora { get; set; }
    public bool Excluido { get; set; }
    public DateTime? DataExclusao { get; set; }
}

public class CreateEquipamentoDto
{
    public string Nome { get; set; } = string.Empty;
    public string Apelido { get; set; } = string.Empty;
    public DateOnly? DataCompra { get; set; }
    public int? PotenciaWatts { get; set; }
    public decimal? ValorCompra { get; set; }
    public int? VidaUtilHoras { get; set; }
}

public class UpdateEquipamentoDto
{
    public Guid IdEquipamento { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Apelido { get; set; } = string.Empty;
    public DateOnly? DataCompra { get; set; }
    public int? PotenciaWatts { get; set; }
    public decimal? ValorCompra { get; set; }
    public int? VidaUtilHoras { get; set; }
}

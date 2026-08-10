namespace PopLume.Application.Dtos;

public class TarifaEnergiaDto
{
    public Guid IdTarifaEnergia { get; set; }
    public decimal ValorKwh { get; set; }
    public DateOnly InicioVigencia { get; set; }
    public DateOnly? FimVigencia { get; set; }
}

public class CreateTarifaEnergiaDto
{
    public decimal? ValorKwh { get; set; }
    public DateOnly? InicioVigencia { get; set; }
    public DateOnly? FimVigencia { get; set; }
}

namespace PopLume.Domain.Entities;

public class TarifaEnergia
{
    public Guid IdTarifaEnergia { get; set; }
    public decimal ValorKwh { get; set; }
    public DateOnly InicioVigencia { get; set; }
    public DateOnly? FimVigencia { get; set; }

    public bool EstaVigenteEm(DateOnly data) =>
        data >= InicioVigencia && (!FimVigencia.HasValue || data <= FimVigencia.Value);
}
